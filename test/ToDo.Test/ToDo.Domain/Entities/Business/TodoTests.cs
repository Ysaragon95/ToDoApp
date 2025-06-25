using ToDo.Domain.Entities.Business;
using ToDo.Domain.Enum;

namespace ToDo.Test.ToDo.Domain.Entities.Business
{
    [TestClass]
    public class TodoTests
    {
        [TestMethod]
        public void Todo_Creation_ShouldInitializeCorrectly()
        {
            // Arrange
            string expectedName = "Tarea de prueba";
            string expectedDescription = "Descripción de prueba";
            EnumStateTodo expectedStatus = EnumStateTodo.NotStarted;
            bool expectedIsCompleted = false;
            int expectedUserId = 1;

            // Act
            var todo = new Todo
            {
                Name = expectedName,
                Description = expectedDescription,
                Status = expectedStatus,
                IsCompleted = expectedIsCompleted,
                IdUserCreate = expectedUserId
            };

            // Assert
            Assert.AreEqual(expectedName, todo.Name);
            Assert.AreEqual(expectedDescription, todo.Description);
            Assert.AreEqual(expectedStatus, todo.Status);
            Assert.AreEqual(expectedIsCompleted, todo.IsCompleted);
            Assert.AreEqual(expectedUserId, todo.IdUserCreate);
            Assert.IsTrue(todo.StatusRegister);
            Assert.IsNotNull(todo.CreateDate);
            Assert.IsNull(todo.UpdateDate);
            Assert.AreEqual("Registro del sistema", todo.OperationRegister);
        }
    }
}
