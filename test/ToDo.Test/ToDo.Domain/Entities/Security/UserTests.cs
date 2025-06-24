using ToDo.Domain.Entities.Security;

namespace ToDo.Test.ToDo.Domain.Entities.Security
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void User_HasDefaultValues()
        {
            // Act
            User user = new User();

            // Assert
            Assert.AreEqual(null, user.Name);
        }
    }
}
