using System;

namespace thirtwo.API.Interfaces
{
    public interface IRequestAPI<T>
    {
        public event Action<string> APIRequestFailed;
        public event Action<T> APIRequestSucceed;
        public void GetAPIData();
    }
}
