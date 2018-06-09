using NotFlix.DataTransferObjects.Video;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notflix.Services
{
	public interface IVideoService
	{
		Task<List<VideoGendersDto>> GetGenders();
		Task UploadVideo(VideoUploadDto videoDto, string path);
	}
}