﻿namespace RecordShop.Model
{
    public class Genre : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
