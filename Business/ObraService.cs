using Microsoft.Extensions.Logging;
using UrbanTheater.Models;
using UrbanTheater.Data;
using System.Collections.Generic;

namespace UrbanTheater.Business
{
    public class ObraService : IObraService
    {
        private readonly IObraRepository _obraRepository;
        private readonly ILogger<ObraService> _logger;


        public ObraService(IObraRepository obraRepository, ILogger<ObraService> logger)
        {
            _obraRepository = obraRepository;
            _logger = logger;
        }

        public List<Obra> GetAll()
        {
            try
            {
                _logger.LogInformation("Obteniendo todas las obras");
                return _obraRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todas las obras");
                throw;
            }
        }
        public Obra? Get(int id)
        {
            try
            {
                return _obraRepository.Get(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo la obra por id");
                throw;
            }

        }
        public List<Obra> SearchObraParameters(QueryParameters queryParameters)
        {
            try
            {
                var obraQuery = _obraRepository.GetAll().AsQueryable();

                if (!string.IsNullOrEmpty(queryParameters.Nombre))
                {
                    obraQuery = obraQuery.Where(x => x.Nombre.Contains(queryParameters.Nombre));
                }

                if (!string.IsNullOrEmpty(queryParameters.Descripcion))
                {
                    obraQuery = obraQuery.Where(x => x.Descripcion.Contains(queryParameters.Descripcion));
                }

                if (!string.IsNullOrEmpty(queryParameters.Autores))
                {
                    obraQuery = obraQuery.Where(x => x.Autores.Contains(queryParameters.Autores));
                }

                if (queryParameters.Duracion != null)
                {
                    obraQuery = obraQuery.Where(x => x.Duracion == queryParameters.Duracion);
                }

                if (!string.IsNullOrEmpty(queryParameters.Actores))
                {
                    obraQuery = obraQuery.Where(x => x.Actores.Contains(queryParameters.Actores));
                }

                if (queryParameters.FechaUno != null)
                {
                    obraQuery = obraQuery.Where(x => x.FechaUno == queryParameters.FechaUno);
                }

                if (queryParameters.FechaDos != null)
                {
                    obraQuery = obraQuery.Where(x => x.FechaDos == queryParameters.FechaDos);
                }

                if (queryParameters.FechaTres != null)
                {
                    obraQuery = obraQuery.Where(x => x.FechaTres == queryParameters.FechaTres);
                }

                var obra = obraQuery.ToList();

                return obra;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo las obras por parametros");
                throw;
            }
        }

        public Obra GetByName(string name)
        {
            try
            {
                return _obraRepository.GetByName(name);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo las obras por nombre");
                throw;

            }
        }
        public void Update(Obra obra)
        {
            try
            {
                _obraRepository.Update(obra);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error actualizando la obra por id");
                throw;
            }
        }



        public void Add(Obra obra)
        {
            try
            {
                _obraRepository.Add(obra);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error añadiendo la obra");
                throw;
            }

        }
        public void Delete(int id)
        {
            try
            {
                _obraRepository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error eliminando la obra");
                throw;
            }

        }


        public List<int> GetObrasAsientos(int ObraID, int IdSesion)
        {
            try
            {
                return _obraRepository.GetObrasAsientos(ObraID, IdSesion);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo los asientos ocupados");
                throw;

            }
        }


        public void AddAsientoToObra(int obraId, int sessionId, int idAsiento)
        {
            try
            {
                _obraRepository.AddAsientoToObra(obraId, sessionId, idAsiento);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error añadiendo los asientos ocupados");
                throw;
            }
        }


    }
}
