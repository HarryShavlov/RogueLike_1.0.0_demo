using RogueLike_1._0._0_demo.data.game_core.event_manager.position_checker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_1._0._0_demo.data.game_objects.static_object
{
    internal class StaticObject(char sprite, string title, Position position, bool passable = false) : IGameObject
    {
        private GameObject obj = new(sprite, title, position, passable);

        public Guid id => obj.id;
        public string title => obj.title;
        public char sprite { get => obj.sprite; private set => obj.sprite = value; }
        public Position position { get => obj.position; private set => obj.position = value; }
        public bool passable { get => obj.passable; private set => obj.passable = value; }
        

        public IGameObject add_with_new_position(Position new_position) => new StaticObject(obj.sprite, obj.title, new_position, obj.passable);

    }
}
