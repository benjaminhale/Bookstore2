using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore2.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem (Book book, int qty)
        {
            CartLine line = Lines
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = qty,
                    Price = book.Price
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveLine(Book book) =>
            Lines.RemoveAll(x => x.Book.BookId == book.BookId);

        public virtual void Clear() => Lines.Clear();

        public decimal ComputeTotalSum() => Lines.Sum(e => (decimal)e.Price * e.Quantity); //Price is hard-coded


        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }

        }
    }
}
