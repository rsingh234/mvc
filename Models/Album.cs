using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Store.Models
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        [Column(TypeName = "varchar")]
        public string Title { get; set; }
        public double Price { get; set; }

        [Column(TypeName = "varchar")]
        public string AlbumArtUrl { get; set; }

        public Genre Genre { get; set; }
        [ForeignKey("Genre")]
        public int GenreId { get; set; }

        [ForeignKey("Artist")]
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
       

    }
}