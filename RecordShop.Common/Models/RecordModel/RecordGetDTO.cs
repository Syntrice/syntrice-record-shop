﻿using RecordShop.Common.Models;

namespace RecordShop.Common.Models.RecordModel
{
    public class RecordGetDTO : IGetDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Artist { get; set; } = null!;
        public int ReleaseYear { get; set; }
        public string Genre { get; set; } = null!;
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
    }
}