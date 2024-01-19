using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AlbumsBusiness
    {
        readonly AlbumsRepository _lbumsRepository = new AlbumsRepository();

        public List<Album> GetAllAlbums()
        {
            return _lbumsRepository.GetAllAlbums().ToList();
        }

        public List<Album> GetAllAlbumsInRange(int start, int end)
        {
            return _lbumsRepository.GetAllAlbums().Where(i => i.Price >= start && i.Price <= end).ToList();
        }

        public bool InsertAlbum(Album album)
        {
            return _lbumsRepository.InsertAlbum(album) != 0;
        }

        public bool DeleteAlbum(int id)
        {
            return _lbumsRepository.DeleteAlbum(id) != 0;
        }

        public bool UpdateAlbum(Album album)
        {
            return _lbumsRepository.UpdateAlbum(album) != 0;
        }
    }
}
