using ServiceLayer.Implementation;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TestContext())
            {
                var userService = new UserService(context);

                var toCreate = new ViewModel.User.Create
                {
                };


            }

        }
    }
}
