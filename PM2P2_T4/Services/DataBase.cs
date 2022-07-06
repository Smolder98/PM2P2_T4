using PM2P2_T4.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM2P2_T4.Services
{
    public class DataBase
    {

        readonly SQLiteAsyncConnection dbase;

        public DataBase(string path)
        {
            dbase = new SQLiteAsyncConnection(path);

            dbase.CreateTableAsync<Video>();
        }

        #region OperacionesVideo
        //Metodos CRUD - CREATE
        public Task<int> insertUpdateVideo(Video video)
        {
            if (video.Id != 0)
            {
                return dbase.UpdateAsync(video);
            }
            else
            {
                return dbase.InsertAsync(video);
            }
        }

        //Metodos CRUD - READ
        public Task<List<Video>> getListVideo()
        {
            return dbase.Table<Video>().ToListAsync();
        }

        public Task<Video> getVideo(int id)
        {
            return dbase.Table<Video>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        //Metodos CRUD - DELETE
        public Task<int> deleteVideo(Video video)
        {
            return dbase.DeleteAsync(video);
        }

        #endregion OperacionesVideo

    }
}
