﻿using System.Xml.Schema;
using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    internal class CheckWinSystem : IEcsRunSystem
    {
        private EcsFilter<CheckWin, Position> _filter;
        private GameState _gameState;
        private SceneData _sceneData;
        private EcsWorld _world;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                var position = _filter.Get2(index).value;

                //check horizontal
                {
                    var crossNumber = 0;
                    var ringNumber = 0;
                    for (int x = 0; x < _sceneData.Width; x++)
                    {
                        var pos = new Vector2Int(x, position.y);
                        var entity = _gameState.Cells[pos];

                        if (entity.Has<Cross>())
                        {
                            crossNumber++;
                        }

                        if (entity.Has<Ring>())
                        {
                            ringNumber++;
                        }
                    }

                    if (ringNumber == 3)
                    {
                        _world.NewEntity().Set<Win>().IsCross = false;
                    }
                    
                    if (crossNumber == 3)
                    {
                        _world.NewEntity().Set<Win>().IsCross = true;
                    }
                }

                //check vertical
                {
                    var crossNumber = 0;
                    var ringNumber = 0;
                    for (int y = 0; y < _sceneData.Height; y++)
                    {
                        var pos = new Vector2Int(position.x, y);
                        var entity = _gameState.Cells[pos];

                        if (entity.Has<Cross>())
                        {
                            crossNumber++;
                        }

                        if (entity.Has<Ring>())
                        {
                            ringNumber++;
                        }
                    }

                    if (ringNumber == 3)
                    {
                        _world.NewEntity().Set<Win>().IsCross = false;
                    }
                    
                    if (crossNumber == 3)
                    {
                        _world.NewEntity().Set<Win>().IsCross = true;
                    }
                }
                
                //check diagonal 1
                {
                    var crossNumber = 0;
                    var ringNumber = 0;
                    for (int y = 0, x = 0; y < _sceneData.Width; x++, y++)
                    {
                        var pos = new Vector2Int(x, y);
                        var entity = _gameState.Cells[pos];

                        if (entity.Has<Cross>())
                        {
                            crossNumber++;
                        }

                        if (entity.Has<Ring>())
                        {
                            ringNumber++;
                        }
                    }

                    if (ringNumber == 3)
                    {
                        _world.NewEntity().Set<Win>().IsCross = false;
                    }
                    
                    if (crossNumber == 3)
                    {
                        _world.NewEntity().Set<Win>().IsCross = true;
                    }
                }
                
                //check diagonal 2
                {
                    var crossNumber = 0;
                    var ringNumber = 0;
                    for (int y = _sceneData.Height - 1, x = 0; y >= 0; x++, y--)
                    {
                        var pos = new Vector2Int(x, y);
                        var entity = _gameState.Cells[pos];

                        if (entity.Has<Cross>())
                        {
                            crossNumber++;
                        }

                        if (entity.Has<Ring>())
                        {
                            ringNumber++;
                        }
                    }

                    if (ringNumber == 3)
                    {
                        _world.NewEntity().Set<Win>().IsCross = false;
                    }
                    
                    if (crossNumber == 3)
                    {
                        _world.NewEntity().Set<Win>().IsCross = true;
                    }
                }


                _filter.GetEntity(index).Unset<CheckWin>();
            }
        }
    }
}