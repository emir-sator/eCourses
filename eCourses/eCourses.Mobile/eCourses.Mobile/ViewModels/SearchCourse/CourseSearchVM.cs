using eCourses.Mobile.Helpers;
using eCourses.Model;
using eCourses.Model.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eCourses.Mobile.ViewModels.SearchCourse
{
    public class CourseSearchVM : BaseVM
    {

        private readonly APIService courseService = new APIService("Course");
        private readonly APIService subcategoryService = new APIService("Subcategory");
        private readonly APIService categoryService = new APIService("Category");
        public ObservableCollection<CourseVM> courseList { get; set; } = new ObservableCollection<CourseVM>();
        public ObservableCollection<MCategory> categoryList { get; set; } = new ObservableCollection<MCategory>();
        public ObservableCollection<MSubcategory> subcategoryList { get; set; } = new ObservableCollection<MSubcategory>();
        public ICommand InitCommand { get; set; }

        readonly MUser user = SignedInUser.User;
        public CourseSearchVM()
        {
            InitCommand = new Command(async () => await Init(user));
        }

        MCategory _selectedCategory = null;

        public MCategory SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                SetProperty(ref _selectedCategory, value);
                subcategoryList.Clear();
                getSubcategories();

            }
        }

        MSubcategory _selectedSubcategory = null;
        public MSubcategory SelectedSubcategory
        {
            get { return _selectedSubcategory; }
            set
            {
                SetProperty(ref _selectedSubcategory, value);
                if (value != null)
                    InitCommand.Execute(null);

            }
        }


        public async void getSubcategories()
        {
            courseList.Clear();
            if (subcategoryList.Count == 0)
            {

                SubcategorySearchRequest search = new SubcategorySearchRequest
                {
                    CategoryID = _selectedCategory.CategoryID
                };
                subcategoryList.Clear();
                var subcategories = await subcategoryService.Get<List<MSubcategory>>(search);
                foreach (var subcategory in subcategories)
                {
                    subcategoryList.Add(subcategory);

                }
            }
        }

        public async Task Init(MUser user)
        {
            try
            {
                if (categoryList.Count == 0)
                {
                    categoryList.Clear();
                    var categories = await categoryService.Get<List<MCategory>>(null);
                    foreach (var category in categories)
                    {
                        categoryList.Add(category);
                    }
                }

                if (SelectedCategory != null)
                {
                    int userID;
                    if (SelectedSubcategory != null)
                    {
                        CourseSearchRequest search1 = new CourseSearchRequest
                        {
                            SubcategoryID = _selectedSubcategory.SubcategoryID
                        };
                        courseList.Clear();

                        var courses = await courseService.Get<List<MCourse>>(search1);

                        foreach (var x in courses)
                        {

                            userID = SignedInUser.User.UserID;
                            var usersBoughtCourses = await courseService.GetBoughtCourses(userID);
                            var DoesItContain = usersBoughtCourses.Where(m => m.CourseID == x.CourseID).Any();
                            if (usersBoughtCourses.Count > 0)
                            {
                                if (DoesItContain == false&&x.UserID!=user.UserID)
                                {
                                    courseList.Add(new CourseVM(x));
                                }
                            }                           
                            else if(x.UserID!=user.UserID)
                            {
                                courseList.Add(new CourseVM(x));
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

        }
    }
}


