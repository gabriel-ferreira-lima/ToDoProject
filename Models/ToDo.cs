namespace TodoList.Models {
    public class ToDo {
        public long Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public int Priority { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }

        //Associação
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
