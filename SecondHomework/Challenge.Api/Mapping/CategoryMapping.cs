using System;
using Challenge.Api.Dtos;
using Challenge.Api.Entities;

namespace Challenge.Api.Mapping;

public static class CategoryMapping
{
    public static CategoryDto ToDto(this Category category)
    {
        return new CategoryDto(category.Id, category.CategoryName);
    }

}