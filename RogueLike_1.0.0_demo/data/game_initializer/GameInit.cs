using RogueLike_1._0._0_demo.assets;
using RogueLike_1._0._0_demo.data.game_core.event_manager.position_checker;
using RogueLike_1._0._0_demo.data.game_core.game_scene_manager;
using RogueLike_1._0._0_demo.data.game_objects;
using RogueLike_1._0._0_demo.map;
using RogueLike_1._0._0_demo.settings.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_1._0._0_demo.data.game_initializer
{
    public class GameInit(
             IConfig Config,
             IGameSceneManager GameScene,
             IAssetsInit Prefs,
             IMapGenerator MapGenerator
            ) : IGameInit
    {
        private readonly IConfig config = Config;
        private readonly IGameSceneManager game_scene = GameScene;
        private readonly IAssetsInit prefs = Prefs;
        private readonly IMapGenerator map_generator = MapGenerator;

        public void init()
        {
            game_scene.clear();

            IGameObject player = prefs.create("Player", new Position(1, 1));
            IGameObject finish = prefs.create("Finish", new Position(config.map_width - 2, config.map_height - 2));

            game_scene.add(player);
            config.set_player_id(player.id);

            game_scene.add(finish);
            config.set_finish_id(finish.id);

            map_generator.generate_map();
        }
    }

}

