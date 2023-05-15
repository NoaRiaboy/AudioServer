using AudioServer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AudioServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AudioController : ControllerBase
{
    private readonly IAudioRepository _audioRepository;

    public AudioController(IAudioRepository audioRepository)
    {
        _audioRepository = audioRepository;
    }

    [HttpGet("[action]")]
    public void GetRecord(string path, ushort secondToRecord)
    {
        _audioRepository.Record(path, secondToRecord);
    }
}