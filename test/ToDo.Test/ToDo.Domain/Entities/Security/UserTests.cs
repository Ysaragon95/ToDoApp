using ToDo.Domain.Entities.Security;

namespace ToDo.Test.ToDo.Domain.Entities.Security
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void User_Creation_ShouldInitializeCorrectly()
        {
            // Arrange
            string expectedName = "Yedsi";
            string expectedLastName = "Aragon";
            string expectedEmail = "yedsi@example.com";
            string expectedPasswordHash = "hashed-password-123";

            // Act
            var user = new User
            {
                Name = expectedName,
                LastName = expectedLastName,
                Email = expectedEmail,
                PasswordHash = expectedPasswordHash
            };

            // Assert
            Assert.AreEqual(expectedName, user.Name);
            Assert.AreEqual(expectedLastName, user.LastName);
            Assert.AreEqual(expectedEmail, user.Email);
            Assert.AreEqual(expectedPasswordHash, user.PasswordHash);

            // EntityBase asserts
            Assert.IsTrue(user.StatusRegister);
            Assert.IsNotNull(user.CreateDate);
            Assert.IsNull(user.UpdateDate);
            Assert.AreEqual("Registro del sistema", user.OperationRegister);
        }
    }
}
