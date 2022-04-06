﻿using AutoMapper;
using Entity.Models;
using WebAPI.Model.Dto.Book;

namespace WebAPI.Model
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookCreateDto, Book>();
            CreateMap<Book, BookResponseDto>();
            CreateMap<BookUpdateDto, Book>();
        }
    }
}