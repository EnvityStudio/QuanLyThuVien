using QuanLyThuVien.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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

            var users = new List<User> {
                new User {
                    UID = "khanhlq", FirstName = "Le", LastName="Khanh", Email="khanhle@gmail.com", 
                    Gender="male", Address="Thanh Xuan", Phone="0192318239", Password="khanhlq", ConfirmPassword="khanhlq"
                }, 
                new User {
                    UID = "namle", FirstName = "Nam", LastName="Le", Email="namle@gmail.com", 
                    Gender="male", Address="Cau giay", Phone="0983812388", Password="name123", ConfirmPassword="name123"
                }, 
                new User {
                    UID = "dongson", FirstName = "Dong", LastName="Son", Email="dongson@gmail.com", 
                    Gender="male", Address="Hoang Hoa", Phone="0983892388", Password="123456", ConfirmPassword="123456"
                }
            };

            users.ForEach(user => context.Users.Add(user));
            context.SaveChanges();

            var authors = new List<Author> {
                new Author {
                    FirstName = "Viet Thanh", LastName = "Nguyen", Gender = "male",
                    BirthDay = "1972", Country="VietNam", Bio = "Viet Thanh Nguyen is a Vietnamese American novelist. He is the Aerol Arnold Chair of English and Professor of English and American Studies and Ethnicity at the University of Southern California"
                },
                new Author {
                    FirstName = "J.r", LastName = "Rowling", Gender = "female",
                    BirthDay = "1970", Country="Bristain", Bio = @"Joanne 'Jo' Rowling, OBE, FRSL, pen names J. K. Rowling and Robert Galbraith, is a British novelist, screenwriter and film producer best known as the author of the Harry Potter fantasy series"
                },
                new Author {
                    FirstName = "Tô", LastName = "Hoài", Gender = "male",
                    BirthDay = "1940", Country="VietNam", Bio = @"Tô Hoài was a Vietnamese writer. Some of his works have been translated into foreign languages. He won the Ho Chi Minh Prize for Literature in 1996."
                },
                new Author {
                    FirstName = "Nam", LastName = "Cao", Gender = "male",
                    BirthDay = "1920", Country="VietNam", Bio = @"Trần Hữu Tri (1915—1951), commonly known by his pseudonym Nam Cao, was a Vietnamese short story writer and novelist. His works generally received high."
                },
                new Author {
                    FirstName = "Murakari", LastName = "Takasi", Gender = "male",
                    BirthDay = "1950", Country="Japan", Bio = @"A famous writter in Japan."
                },
                new Author {
                    FirstName = "Nguyễn Nhật", LastName = "Ánh", Gender = "male",
                    BirthDay = "1950", Country="VietNam", Bio = @"Nguyễn Nhật Ánh is a Vietnamese author who writes for teenagers and adults. He also works as a teacher, poet and correspondent. His works include approximately 24 short stories, 2 novel series and some collections of poems."
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
                },
                new Publisher {
                    Name= "Nhà xuất bản Nhã Nam", Address = "Nguyễn Thái học", Phone = "041823198", Intro="Nhà xuất bản Kim Đồng trực thuộc Trung ương Đoàn TNCS Hồ Chí Minh là Nhà xuất bản tổng hợp có chức năng xuất bản sách và văn hóa phẩm phục vụ thiếu"
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
                },
                new Category {
                    Name = "Truyện thiếu nhi", Description = "Tuyển tập truyện thiếu nhi nổi tiếng trong nước"
                },
                new Category {
                    Name = "Truyện trinh thám", Description = "Tuyển tập truyện trinh thám nổi tiếng trong nước"
                },
                new Category {
                    Name = "Truyện khoa học viễn tưởng", Description = "Tuyển tập truyện thiếu nhi nổi tiếng trong nước"
                },
                new Category {
                    Name = "Truyện ngôn tình", Description = "Tuyển tập truyện thiếu nhi nổi tiếng trong nước"
                },
            };
            categories.ForEach(category => context.Categories.Add(category));
            context.SaveChanges();

            var books = new List<Book> {
                new Book {
                    Name = "Tấm Cám", PublisherID = 1, CategoryID=3, AuthorID=1,  Description="Truyện cổ tích Việt Nam", Price=30000
                },
                new Book {
                    Name = "Thạch sanh", PublisherID = 1, CategoryID=3, AuthorID=2, Description="Truyện cổ tích Việt Nam", Price=30000
                },
                new Book {
                    Name = "War and Peace", PublisherID = 2, CategoryID=2 , AuthorID=2, Description="Truyện kinh điển văn học Nga", Price=180000
                },
                new Book {
                    Name = "Catcher in the rye", PublisherID = 2, CategoryID=2, AuthorID=3, Description="Truyện lãng mạn", Price=50000
                },
                new Book {
                    Name = "AQZ", PublisherID = 1, CategoryID=4, AuthorID=2 ,Description="A classic book of Africa", Price=130000
                },
                new Book {
                    Name = "Dế mèn phưu lưu ký", PublisherID = 2, CategoryID=2 , AuthorID=2 ,  Description="Truyện thiếu nhi của nhà văn Tô Hoài", Price=23000
                },
                new Book {
                    Name = "1Q94", PublisherID = 2, CategoryID=6,  AuthorID=3, Description="Murakami", Price=230000
                }
            };
            books.ForEach(book => context.Books.Add(book));
            context.SaveChanges();

            var orders = new List<Order> {
                new Order {
                    UserID = 1, BookID = 1,
                    BorrowedDate = 
                    DateTime.ParseExact("24/01/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    ExpiredDate = 
                    DateTime.ParseExact("24/02/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture)
                },
                new Order {
                    UserID = 1, BookID = 2,
                    BorrowedDate = 
                    DateTime.ParseExact("24/01/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    ExpiredDate = 
                    DateTime.ParseExact("24/02/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture)
                },
                new Order {
                    UserID = 2, BookID = 3,
                    BorrowedDate = 
                    DateTime.ParseExact("30/01/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    ExpiredDate = 
                    DateTime.ParseExact("30/03/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture)
                }

            };
            orders.ForEach(order => context.Orders.Add(order));
            context.SaveChanges();


            base.Seed(context);
        }
    }
}