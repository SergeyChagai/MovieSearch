SELECT * FROM Movies m
JOIN MovieActors ma ON (ma.MovieId = m.Id)
JOIN Actors a ON (a.Id = ma.ActorId)
JOIN MovieGenres mg ON (mg.MovieId = m.Id)
JOIN Genres g ON (g.Id = mg.GenreId)