namespace TodoList.Models {
    public class User {

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;


        //associação
        public List<ToDo> ToDos { get; set; } = new List<ToDo>();
    }
}
