﻿using QuanLyThuVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyThuVien.DAL {
    public class LibraryInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LibraryContext>{
        protected override void Seed(LibraryContext context) {
            var librarians = new List<Librarian> {
                new Librarian {
                    UID = "admin", FirstName="Admin", LastName="Master", Gender="Male",
                    Password ="123", ConfirmPassword="123", Address="Cầu giấy", Email = "admin@gmail.com" },
                new Librarian {
                    UID = "huyenanh", FirstName="Huyền", LastName="Anh", Gender="Female",
                    Password ="123", ConfirmPassword="123", Address="Nghĩa Đô" , Email = "huyenanh@gmail.com"},
                new Librarian {
                    UID = "nguyenanh", FirstName="Nguyễn", LastName="Anh", Gender="Male",
                    Password ="123", ConfirmPassword="123", Address="Láng" , Email = "nguyenanh@gmail.com", Phone="09882839182"},
                new Librarian {
                    UID = "lamtran", FirstName="Lâm", LastName="Trần", Gender="Male",
                    Password ="123", ConfirmPassword="123", Address="Ngã tư sở" , Email = "lammtran.12@gmail.com", Phone="09882839182"},
                new Librarian {
                    UID = "vuanhminh", FirstName="Vũ anh", LastName="Minh", Gender="Male",
                    Password ="123", ConfirmPassword="123", Address="Hà Đông" , Email = "vuanhminh@gmail.com", Phone="09882839182"},
                new Librarian {
                    UID = "tulong", FirstName="Tự", LastName="Long", Gender="Male",
                    Password ="123", ConfirmPassword="123", Address="Trường Chinh" , Email = "tulong.haihuoc@gmail.com", Phone="09882839182"}
            };
            librarians.ForEach(libs => context.Librarians.Add(libs));
            context.SaveChanges();

            var authors = new List<Author> {
                new Author {
                    FirstName = "Viet Thanh", LastName = "Nguyen", Gender = "male",
                    BirthDay = "1972", Country="VietNam", Bio = "Viet Thanh Nguyen is a Vietnamese American novelist. He is the Aerol Arnold Chair of English and Professor of English and American Studies and Ethnicity at the University of Southern California"
                },
                new Author {
                    FirstName = "J.r", LastName = "Rowling", Gender = "female",
                    BirthDay = "1970", Country="Bristain", Bio = @"Joanne 'Jo' Rowling, OBE, FRSL, pen names J. K. Rowling and Robert Galbraith, is a British novelist, screenwriter and film producer best known as the author of the Harry Potter fantasy series"
                }
            };
            authors.ForEach(author => context.Authors.Add(author));
            context.SaveChanges();

            var publishers = new List<Publisher> {
                new Publisher {
                    Name= "Nhà xuất bản giáo dục", Address = "214 Ba Đình", Phone = "0482292892", Intro="Nhà xuất bản Giáo dục Việt Nam nhận bằng khen đơn vị đạt thành tích xuất sắc trong phong trào thi đua trong lĩnh vực xuất bản, in và phát hành"
                },
                new Publisher {
                    Name= "Nhà xuất bản Kim Đồng", Address = "91 Trần Thái Tông", Phone = "041823198", Intro="Nhà xuất bản Kim Đồng trực thuộc Trung ương Đoàn TNCS Hồ Chí Minh là Nhà xuất bản tổng hợp có chức năng xuất bản sách và văn hóa phẩm phục vụ thiếu"
                }
            };
            publishers.ForEach(publisher => context.Publishers.Add(publisher));
            context.SaveChanges();

            var categories = new List<Category> {
                new Category {
                    Name = "Văn học trong nước", Description = "Tuyển tập các tác phẩm văn học nổi tiếng trong nước"
                },
                new Category {
                    Name = "Tiểu thuyết lãng mạn", Description = "Tuyển tập các tác phẩm văn học nổi tiếng trong và ngoài nước"
                }
            };
            categories.ForEach(category => context.Categories.Add(category));
            context.SaveChanges();

            var books = new List<Book> {
                new Book {
                    Name = "Tấm Cám", PublisherID = 1, Description="Truyện cổ tích Việt Nam", Price=30000
                }, 
                new Book {
                    Name = "Thạch sanh", PublisherID = 1, Description="Truyện cổ tích Việt Nam", Price=30000
                }, 
                new Book {
                    Name = "War and Peace", PublisherID = 2, Description="Truyện kinh điển văn học Nga", Price=180000
                }
            };
            books.ForEach(book => context.Books.Add(book));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}