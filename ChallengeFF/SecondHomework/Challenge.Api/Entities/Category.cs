using System;
namespace Challenge.Api.Entities;

//define method to use with DB
public class Category
    {
        public int Id { get; set; }

        public required string CategoryName { get; set; }
        


    }