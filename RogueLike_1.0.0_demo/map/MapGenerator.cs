using RogueLike_1._0._0_demo.assets;
using RogueLike_1._0._0_demo.data.game_core.event_manager.position_checker;
using RogueLike_1._0._0_demo.data.game_core.game_scene_manager;
using RogueLike_1._0._0_demo.settings.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_1._0._0_demo.map
{
    public class MapGenerator(
                                IConfig Config,
                                IGameSceneManager GameScene,
                                IAssetsInit Prefs
                            ) : IMapGenerator
    {
        private readonly IConfig config = Config;
        private readonly IGameSceneManager game_scene = GameScene;
        private readonly IAssetsInit prefs = Prefs;

        public void generate_map()
        {
            bool[,] map = new bool[config.map_width, config.map_height];
            initialize_map(map);

            Position start = get_position_by_id(config.id_player);
            Position finish = get_position_by_id(config.id_finish);

            carve_passages_from(start, map);
            ensure_finish_is_accessible(finish, map);
            construct_walls(map);
        }

        private void initialize_map(bool[,] map)
        {
            for (int x = 0; x < config.map_width; x++)
                for (int y = 0; y < config.map_height; y++)
                    map[x, y] = true;
        }

        private Position get_position_by_id(Guid id) => game_scene.find_by_id(id).position;

        private void carve_passages_from(Position current, bool[,] map)
        {
            map[current.x, current.y] = false;
            var directions = new Position[] { new(0, -2), new(2, 0), new(0, 2), new(-2, 0) };
            directions = shuffle(directions);

            foreach (var direction in directions)
            {
                Position new_pos = current + direction;
                Position between = current + direction / 2;

                if (is_inside_bounds(new_pos) && map[new_pos.x, new_pos.y])
                {
                    map[between.x, between.y] = false;
                    carve_passages_from(new_pos, map);
                }
            }
        }

        private void ensure_finish_is_accessible(Position finish, bool[,] map)
        {
            foreach (var direction in new Position[] { new(0, -1), new(1, 0), new(0, 1), new(-1, 0), new(0, 0) })
            {
                Position new_pos = finish + direction;

                if (is_inside_bounds(new_pos))
                    map[new_pos.x, new_pos.y] = false;
            }
        }

        private void construct_walls(bool[,] map)
        {
            for (int x = 0; x < config.map_width; x++)
                for (int y = 0; y < config.map_height; y++)
                    if (map[x, y])
                        game_scene.add(prefs.create("Wall", new Position(x, y)));
        }

        private static Position[] shuffle(Position[] positions)
        {
            for (int i = positions.Length - 1; i > 0; i--)
            {
                int j = Random.Shared.Next(i + 1);
                (positions[i], positions[j]) = (positions[j], positions[i]);
            }
            return positions;
        }

        private bool is_inside_bounds(Position position) =>
            position.x > 0 && position.x < config.map_width - 1 && position.y > 0 && position.y < config.map_height - 1;
    }

}
