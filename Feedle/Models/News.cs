﻿using System;

namespace Feedle.Models
{
    [Serializable]
    public class News
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
    }
}