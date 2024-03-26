using RogueLike_1._0._0_demo.data.game_core.event_manager.position_checker;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_1._0._0_demo.data.game_objects.dynamic_object
{
    public class DynamicObject(char sprite, string title, Position position, bool passable,int HP) : IGameObject
    {

        private GameObject obj = new GameObject(sprite, title, position, passable);
        public int hp { get; private set; } = HP;
        public Guid id => obj.id;
        public string title => obj.title;
        public char sprite { get => obj.sprite; private set => obj.sprite = value; }
        public Position position { get => obj.position; private set => obj.position = value; }
        public bool passable { get => obj.passable; private set => obj.passable = value; }

        public void move(Direction direction, Func<Position, bool> canMove)
        {
            Position new_position = position.new_position(direction);

            if (canMove(new_position))
                position = new_position;
        }

        public IGameObject add_with_new_position( Position new_position) => new DynamicObject(obj.sprite, obj.title, new_position, obj.passable, HP);

    }
}
