using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Тумаков___Лабораторная_8_главы.ClassesTumakov
{
    public class Song
    {
        private string name; // название песни
        private string author; // автор песни
        private Song prev; // связь с предыдущей песней в списке

        /// <summary>
        /// Метод для заполнения поля name
        /// </summary>
        /// <param name="name">Название песни</param>
        public void SetName(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Метод для заполнения поля author
        /// </summary>
        /// <param name="author">Автор песни</param>
        public void SetAuthor(string author)
        {
            this.author = author;
        }

        /// <summary>
        /// Метод для заполнения поля prev
        /// </summary>
        /// <param name="prev">Предыдущая песня</param>
        public void SetPrev(Song prev)
        {
            this.prev = prev;
        }

        /// <summary>
        /// Метод для печати названия песни и ее исполнителя
        /// </summary>
        public void Title()
        {
            Console.WriteLine($"Песня: {name}, Исполнитель: {author}");
        }

        /// <summary>
        /// Метод, который сравнивает две песни
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>True, если песни одинаковые; иначе False</returns>
        public override bool Equals(object obj)
        {
            if (obj is Song otherSong)
            {
                return this.name == otherSong.name && this.author == otherSong.author;
            }
            return false;
        }
    }
}
