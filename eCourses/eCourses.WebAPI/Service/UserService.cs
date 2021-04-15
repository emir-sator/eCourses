using AutoMapper;
using eCourses.WebAPI.Database;
using eCourses.WebAPI.Interface;
using eCourses.WebAPI.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Service
{
    public class UserService : CRUDService<MUser, UserSearchRequest, User, UserUpsertRequest, UserUpsertRequest>, IUserService
    {
        private readonly eCoursesContext _context;
        private readonly IMapper _mapper;
        public UserService(eCoursesContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async override Task<List<MUser>> Get(UserSearchRequest search)
        {
            var query = _context.Users.Include(x => x.UserRoles).AsQueryable().OrderBy(c => c.FirstName);

            if (!string.IsNullOrWhiteSpace(search?.Username))
            {
                query = query.Where(x => x.Username.ToLower().StartsWith(search.Username.ToLower())).OrderBy(c => c.FirstName);
            }
            var list = await query.ToListAsync();
            return _mapper.Map<List<MUser>>(list);
        }

        public override async Task<MUser> GetById(int ID)
        {
            var entity = await _context.Set<User>()
                .Where(i => i.UserID == ID)
                .Include(i => i.UserRoles)
                .SingleOrDefaultAsync();

            return _mapper.Map<MUser>(entity);
        }
        public override async Task<MUser> Insert(UserUpsertRequest request)
        {
            if (request.Password != request.PasswordConfirmation)
            {
                throw new Exception("Passwords do not match!");
            }

            var entity = _mapper.Map<User>(request);
            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();

            foreach (var roleID in request.Roles)
            {
                var role = new UserRoles()
                {
                    UserID = entity.UserID,
                    RoleID = roleID
                };

                await _context.UserRoles.AddAsync(role);
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<MUser>(entity);
        }
        public override async Task<MUser> Update(int ID, UserUpsertRequest request)
        {
            var entity = _context.Users.Find(ID);

            _context.Users.Attach(entity);
            _context.Users.Update(entity);

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                if (request.Password != request.PasswordConfirmation)
                {
                    throw new Exception("Passwords do not match!");
                }

                entity.PasswordSalt = GenerateSalt();
                entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);
            }

            foreach (var RoleID in request.Roles)
            {
                var userRole = await _context.UserRoles
                    .Where(i => i.RoleID == RoleID && i.UserID == ID)
                    .SingleOrDefaultAsync();

                if (userRole == null)
                {
                    var newRole = new UserRoles()
                    {
                        UserID = ID,
                        RoleID = RoleID
                    };
                    await _context.Set<UserRoles>().AddAsync(newRole);
                }
            }

            foreach (var RoleID in request.RolesToDelete)
            {
                var userRole = await _context.UserRoles
                    .Where(i => i.RoleID == RoleID && i.UserID == ID)
                    .SingleOrDefaultAsync();

                if (userRole != null)
                {
                    _context.Set<UserRoles>().Remove(userRole);
                }
            }

            _mapper.Map(request, entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MUser>(entity);
        }
        public async Task<MUser> Authenticate(UserAuthenticationRequest request)
        {
            var user = await _context.Users
                .Include(i => i.UserRoles)
                .ThenInclude(j => j.Role)
                .FirstOrDefaultAsync(i => i.Username == request.Username);

            if (user != null)
            {
                var newHash = GenerateHash(user.PasswordSalt, request.Password);

                if (newHash == user.PasswordHash)
                {
                    return _mapper.Map<MUser>(user);
                }
            }
            return null;
        }
        public async Task<MUser> Register(UserUpsertRequest request)
        {
            if (request.Password != request.PasswordConfirmation)
            {
                throw new Exception("Passwords do not match!");
            }
            request.Roles = new List<int> { 2, 3 };
            var entity = _mapper.Map<User>(request);
            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MUser>(entity);
        }
        public override async Task<bool> Delete(int ID)
        {
            var entity = await _context.Users.
                Include(i => i.UserRoles).
                Include(i => i.UserCourseReviews).
                FirstOrDefaultAsync(i => i.UserID == ID);

            if (entity.UserRoles.Count != 0)
                _context.UserRoles.RemoveRange(entity.UserRoles);
            if (entity.UserCourseReviews.Count != 0)
                _context.UserCourseReviews.RemoveRange(entity.UserCourseReviews);

            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<List<MCourse>> GetLikedCourse(int ID, CourseSearchRequest request)
        {
            var query = _context.UserLikedCourses
                 .Include(i => i.Course)
                 .ThenInclude(i=>i.User)
                 .Where(i => i.UserID == ID)
                 .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Name))
            {
                query = query.Where(x => x.Course.Name.StartsWith(request.Name));
            }

            var list = await query.ToListAsync();

            return _mapper.Map<List<MCourse>>(list.Select(i => i.Course).ToList());
        }
        public async Task<MCourse> InsertLikedCourse(int ID, int CourseID)
        {
            var entity = new UserLikedCourse()
            {
                UserID = ID,
                CourseID = CourseID
            };

            await _context.UserLikedCourses.AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MCourse>(entity.Course);
        }
        public async Task<MCourse> DeleteLikedCourse(int ID, int CourseID)
        {
            var entity = await _context.UserLikedCourses
               .Where(i => i.UserID == ID && i.CourseID == CourseID)
               .SingleOrDefaultAsync();
            if (entity != null)
            {
                _context.UserLikedCourses.Remove(entity);
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<MCourse>(entity);
        }

        public async Task<List<MBuyCourse>> GetBoughtCourses(int ID)
        {
            var query = _context.BuyCourses
                .Include(i => i.Course)
                .ThenInclude(i=>i.User)
                .Where(i => i.UserID == ID)
                .AsQueryable();

            var list = await query.ToListAsync();

            return _mapper.Map<List<MBuyCourse>>(list);
        }

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
    }
}
