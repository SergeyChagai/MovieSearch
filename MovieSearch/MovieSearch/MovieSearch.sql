SELECT 
    Movies.Id,
    Movies.Name,
    Actors.Name AS ActorName,
    Genres.Name AS GenreName
FROM Movies
JOIN MovieActors ON Movies.Id = MovieActors.MovieId
JOIN Actors ON MovieActors.ActorId = Actors.Id
JOIN MovieGenres ON Movies.Id = MovieGenres.MovieId
JOIN Genres ON MovieGenres.GenreId = Genres.Id
WHERE 
    (Movies.Name IS NULL OR Movies.Name LIKE '%Pirates of the Caribbean%') AND
    (ActorName IS NULL OR Actors.Name LIKE '%Orlando Bloom%')  AND (GenreName IS NULL OR Genres.Name LIKE '%Action%')
