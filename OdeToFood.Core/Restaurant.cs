﻿namespace OdeToFood.Core
{
    public partial class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public CusineType Cusine { get; set; }
    }
}