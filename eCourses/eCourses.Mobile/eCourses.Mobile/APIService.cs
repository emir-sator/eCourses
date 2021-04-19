using eCourses.Model;
using eCourses.Model.Request;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eCourses.Mobile
{
    public class APIService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }

        private readonly string _route;

        private readonly string ApiURL = "http://localhost:63679/api";
        public APIService(string route)
        {
            _route = route;
        }
        public async Task<MUser> Authenticate(UserAuthenticationRequest request)
        {
            try
            {
                var url = $"{ApiURL}/User/Authenticate";
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<MUser>();
            }
            catch (FlurlHttpException)
            {
                return default;
            }
        }

        public async Task<MUser> Register(UserUpsertRequest request)
        {
            try
            {
                var url = $"{ApiURL}/User/Register";
                return await url.PostJsonAsync(request).ReceiveJson<MUser>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }
        public async Task<T> Get<T>(object search)
        {
            var url = $"{ApiURL}/{_route}";

            try
            {
                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }
                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException)
            {
                return default;
            }
        }
        public async Task<T> GetById<T>(object id)
        {
            var url = $"{ApiURL}/{_route}/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }
        public async Task<T> Insert<T>(object request)
        {
            try
            {
                var url = $"{ApiURL}/{_route}";

                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }
        }
        public async Task<T> Update<T>(int ID, object request)
        {
            try
            {
                var url = $"{ApiURL}/{_route}/{ID}";

                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }
        }
        public async Task<bool> Delete<T>(int ID)
        {
            try
            {
                var url = $"{ApiURL}/{_route}/{ID}";

                return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<bool>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return false;
            }
        }

        public async Task<List<MCourse>> GetLikedCourse(int ID, CourseSearchRequest search)
        {
            try
            {
                var url = $"{ApiURL}/User/{ID}/LikedCourses";

                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<List<MCourse>>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }
        public async Task<MCourse> InsertLikedCourse(int ID, int CourseID)
        {
            try
            {
                var url = $"{ApiURL}/User/{ID}/LikedCourse/{CourseID}";

                return await url.WithBasicAuth(Username, Password).PostJsonAsync(null).ReceiveJson<MCourse>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }
        public async Task<MCourse> DeleteLikedCourse(int ID, int CourseID)
        {
            try
            {
                var url = $"{ApiURL}/User/{ID}/LikedCourse/{CourseID}";

                return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<MCourse>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }

        public async Task<T> GetLectures<T>(int ID, CourseSearchRequest search)
        {
            try
            {
                var url = $"{ApiURL}/{_route}/{ID}/Lectures";

                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }
        }
        public async Task<List<MBuyCourse>> GetBoughtCourses(int ID)
        {
            try
            {
                var url = $"{ApiURL}/User/{ID}/GetBoughtCourses";

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<List<MBuyCourse>>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }
        public async Task<List<MCourse>> GetRecommandedCourses(int ID)
        {
            try
            {
                var url = $"{ApiURL}/{_route}/GetRecommendedCourses?UserID={ID}";

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<List<MCourse>>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }

        public async Task<List<MCourseReview>> UserReviewList<T>(int ID)
        {
            try
            {
                var url = $"{ApiURL}/{_route}/{ID}/Users";
                return await url.WithBasicAuth(Username, Password).GetJsonAsync<List<MCourseReview>>();
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public async Task<float> GetAverageRating<T>(int ID)
        {
            try
            {
                var url = $"{ApiURL}/{_route}/{ID}/GetAvarageRating";

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<float>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }
        public async Task<int> GetTotalStudents<T>(int ID)
        {
            try
            {
                var url = $"{ApiURL}/{_route}/{ID}/GetTotalStudents";

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<int>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }

        }

        public async Task<int> GetTotalInstructorsCourses<T>(int ID)
        {
            try
            {
                var url = $"{ApiURL}/{_route}/{ID}/GetTotalInstructorsCourses";

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<int>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }

        public async Task<int> GetTotalStudentsFromInstructorsCourses<T>(int ID)
        {
            try
            {
                var url = $"{ApiURL}/{_route}/{ID}/GetTotalStudentsFromInstructorsCourses";

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<int>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }

        public async Task<float> GetAverageInstructorsCoursesRating<T>(int ID)
        {
            try
            {
                var url = $"{ApiURL}/{_route}/{ID}/GetAverageInstructorsCoursesRating";

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<float>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }

    }
}
