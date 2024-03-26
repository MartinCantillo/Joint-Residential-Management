using System.Data.Entity;
using DataDataContext.DataContext;
using ModelResidente.Residente;
using RepositoriesIResidente.IResidente;

namespace ServicesResidenteS.SResidente
{
    public class SResidente : IResidente
    {

        private readonly DataContext _DataContext;

        public SResidente(DataContext _DataContext)
        {
            this._DataContext = _DataContext;

        }

        public async Task<ICollection<Residente>> GetAll() => await this._DataContext.Residentes.ToListAsync();


        public async Task<Residente> GetById(int id)
        {
            if (id == 0)
            {
                throw new Exception("Por favor verifica el id");
            }
            else
            {
                var ResidentFound = await this._DataContext.Residentes.FirstOrDefaultAsync(r => r.Id_residente == id);
                return ResidentFound;
            }
        }

        public async Task SaveResidente(Residente r)
        {
            if (r.Nombre_residente == "" || r.Num_apartamento == "" || r.Usuario == null || r.Num_telefono == "")
            {
                throw new Exception("Por favor verificar");
            }
            else
            {
                await this._DataContext.Residentes.AddAsync(r);
                await this._DataContext.SaveChangesAsync();
            }
        }

        public async Task Update(int id, Residente r)
        {
            if (id == 0 || r == null)
            {
                throw new Exception("Por favor verificar");
            }
            else
            {
                var ResidenteFound = await GetById(id);
                ResidenteFound.Nombre_residente = r.Nombre_residente;
                ResidenteFound.Num_apartamento = r.Num_apartamento;
                ResidenteFound.Num_telefono = r.Num_telefono;
                //El usuario no se puede cambiar , solo en la entidad user
                await this._DataContext.SaveChangesAsync();
            }
        }
    }
}