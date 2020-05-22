using System.Collections.ObjectModel;
using FunnyWaterCarrier.Commands;
using FunnyWaterCarrier.DAL.Entities;
using FunnyWaterCarrier.DAL.Providers.Contracts;

namespace FunnyWaterCarrier.Options {
    public class ApplicationView<TEntity> where TEntity : BaseEntity, new() {
        private readonly IDbProvider<TEntity> _dbProvider;

        private AddCommand _addCommand;

        private UpdateCommand _updateUpdateCommand;

        public ApplicationView(IDbProvider<TEntity> dbProvider) {
            _dbProvider = dbProvider;
            Entities = new ObservableCollection<TEntity>(_dbProvider.GetAll());
        }

        public ObservableCollection<TEntity> Entities { get; set; }

        public TEntity SelectedEntity { get; set; }

        public AddCommand AddCommand {
            get {
                return _addCommand ?? (_addCommand = new AddCommand(obj => {
                    TEntity entity = new TEntity();
                    int entityId = _dbProvider.Insert(entity);
                    entity.Id = entityId;
                    Entities.Add(entity);
                }));
            }
        }

        public UpdateCommand UpdateCommand {
            get {
                return _updateUpdateCommand ?? (_updateUpdateCommand = new UpdateCommand(obj => {
                    TEntity entity = obj as TEntity;
                    _dbProvider.Update(entity);
                }));
            }
        }
    }
}