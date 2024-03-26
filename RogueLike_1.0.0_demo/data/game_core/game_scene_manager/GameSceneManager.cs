using RogueLike_1._0._0_demo.data.game_objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RogueLike_1._0._0_demo.data.game_core.game_scene_manager
{
    public class GameSceneManager : IGameSceneManager
    {
        private readonly List<IGameObject> game_objects = new List<IGameObject>();


        public void add(IGameObject game_object) => game_objects.Add(game_object);

        public bool remove(Guid id) => game_objects.Remove(item: game_objects.FirstOrDefault(obj => obj.id == id));

        public IGameObject? find_by_id(Guid id) => game_objects.FirstOrDefault(obj => obj.id == id);

        public IEnumerable<IGameObject> Game_Objects(Func<IGameObject, bool> predicate) => game_objects.Where(predicate).Reverse().ToList();

        public void clear() => game_objects.Clear();
    }
}
