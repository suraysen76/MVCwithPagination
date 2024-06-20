A MVC solution with pagination using Code first entity framework

LinQ Logic:
                dbEntity
                .OrderByDescending(m => m.LastName)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize);
