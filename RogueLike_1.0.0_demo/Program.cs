﻿using RogueLike_1._0._0_demo.assets;
using RogueLike_1._0._0_demo.data.game_core.collision_manager;
using RogueLike_1._0._0_demo.data.game_core.game_loop;
using RogueLike_1._0._0_demo.data.game_core.game_scene_manager;
using RogueLike_1._0._0_demo.data.game_initializer;
using RogueLike_1._0._0_demo.data.game_render;
using RogueLike_1._0._0_demo.map;
using RogueLike_1._0._0_demo.settings.config;
using RogueLike_1._0._0_demo.settings.controller_manager;
class Program
{
    static void Main()
    {
        IConfig config = new Config(20, 20);
        IGameSceneManager game_scene = new GameSceneManager();

        IAssetsInit prefs = new AssetsInit();

        IMapGenerator map_generator= new MapGenerator(config, game_scene, prefs);



        ICollisionManager collisionManager = new CollisionManager(game_scene);

        IControllerManager controller_manager = new ControllerManager(config, game_scene, collisionManager);


        IGameRender gameRender = new GameRender(game_scene, config);
        IGameInit initializer = new GameInit(config, game_scene, prefs, map_generator);
        IGameLoop gameLoop = new GameLoop(config, collisionManager, gameRender, controller_manager, initializer, game_scene);

        gameLoop.run();
    }
}