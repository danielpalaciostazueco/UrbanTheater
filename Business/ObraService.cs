using UrbanTheater.Models;
using UrbanTheater.Data;
using System.Collections.Generic;

namespace UrbanTheater.Business
{
    public class ObraService : IObraService
    {
        private readonly IObraRepository _obraRepository;
        private readonly FileLogger _logger = new FileLogger("Log.Business.txt");
        public ObraService(IObraRepository obraRepository)
        {
            _obraRepository = obraRepository;
        }

        public List<Obra> GetAll()
        {
            try
            {
                return _obraRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.Log($"GetAll de Obra fallado: {ex.Message}");
                return null;
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
                _logger.Log($"Get de Obra fallado: {ex.Message}");
                return null;
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
                _logger.Log($"Get de Obra fallado: {ex.Message}");
                return null;

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
                _logger.Log($"Update de Obra fallado: {ex.Message}");

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
                _logger.Log($"Add de Obra fallado: {ex.Message}");
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
                _logger.Log($"Delete de Obra fallado: {ex.Message}");
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
                _logger.Log($"GetObrasAsientos de Obra fallado: {ex.Message}");
                return null;
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
                _logger.Log($"AddAsientoToObra de Obra fallado: {ex.Message}");
            }
        }


    }
}
