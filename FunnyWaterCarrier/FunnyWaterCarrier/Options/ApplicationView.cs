using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FunnyWaterCarrier.Commands;
using FunnyWaterCarrier.DAL.Entities;
using FunnyWaterCarrier.DAL.Factories;
using FunnyWaterCarrier.DAL.Factories.Contracts;
using FunnyWaterCarrier.DAL.Providers;
using FunnyWaterCarrier.DAL.Providers.Contracts;

namespace FunnyWaterCarrier.Options {
    public class ApplicationView<TEntity> where TEntity : BaseEntity, new() {
        private readonly IDbProvider<TEntity> _dbProvider;
        public ApplicationView(IDbProvider<TEntity> dbProvider) {
            _dbProvider = dbProvider;
            Entities = new ObservableCollection<TEntity>(_dbProvider.GetAll());;
        }
  
        public ObservableCollection<TEntity> Entities { get; set; }

        private TEntity _selectedEntity;
        public TEntity SelectedEntity {
            get => _selectedEntity;
            set => _selectedEntity = value;
        }

        private AddCommand _addUpdateCommand;
        public AddCommand AddUpdateCommand
        {
            get
            {
                return _addUpdateCommand ??
                       (_addUpdateCommand = new AddCommand(obj => {
                           TEntity entity = new TEntity();
                           int entityId = _dbProvider.Insert(entity);
                           entity.Id = entityId;
                           Entities.Add(entity);
                       }));
            }
        }
        
        private UpdateCommand _updateUpdateCommand;
        public UpdateCommand UpdateCommand
        {
            get
            {
                return _updateUpdateCommand ??
                       (_updateUpdateCommand = new UpdateCommand(obj => {
                           TEntity entity = obj as TEntity;
                           _dbProvider.Update(entity);
                       }));
            }
        }
    }
}