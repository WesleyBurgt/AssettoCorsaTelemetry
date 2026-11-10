using AssettoCorsaTelemetry.Core.Entities;
using AssettoCorsaTelemetry.Core.Interfaces;
using AssettoCorsaTelemetry.Dtos;

namespace AssettoCorsaTelemetry.Core.Services;

public class SessionService(ISessionRepository sessionRepository, ICarService carService, ITrackService trackService) : ISessionService
{
    public async Task AddSessionAsync(SessionDto dto, CancellationToken cancellationToken = default)
    {
        Guid userId = Guid.Empty;
        
        await trackService.EnsureTrackExistsAsync(dto.TrackName, dto.TrackConfiguration, cancellationToken);
        Track track = await trackService.GetTrackAsync(dto.TrackName, dto.TrackConfiguration, cancellationToken);
        
        await carService.EnsureCarExistsAsync(userId, dto.CarName, cancellationToken);
        Car car = await carService.GetCarAsync(userId, dto.CarName, cancellationToken);

        Session session = new Session
        {
            Id = dto.Id,
            TrackId = track.Id,
            CarId = car.Id,
            UserId = userId,
        };
        
        await sessionRepository.AddSessionAsync(session, cancellationToken);
    }

    public async Task<Session> GetByIdAsync(Guid sessionId, CancellationToken cancellationToken = default)
    {
        return await sessionRepository.GetByIdAsync(sessionId, cancellationToken);
    }
}