using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FeedMe.Models;
using WebMatrix.WebData;

namespace FeedMe.DAL
{
    public class DbInitializer : DropCreateDatabaseAlways<DatabaseContext>//IfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            WebSecurity.InitializeDatabaseConnection(
                   "DatabaseContext", "UserProfile", "UserId", "UserName", autoCreateTables: true);

            var ingredientes = new List<Ingrediente>
            {
				new Ingrediente { Nome = "Tomate" }, /*1*/
				new Ingrediente { Nome = "Batata" }, /*2*/
				new Ingrediente { Nome = "Massa" },/*3*/
                new Ingrediente { Nome = "Alho" },/*4*/
                new Ingrediente { Nome = "Cebola" },/*5*/
                new Ingrediente { Nome = "Vinho Branco" },/*6*/
                new Ingrediente { Nome = "Whisky" },/*7*/
                new Ingrediente { Nome = "Limão" },/*8*/
                new Ingrediente { Nome = "Molho Inglês" },/*9*/
                new Ingrediente { Nome = "Polpa de Tomate" },/*10*/
                new Ingrediente { Nome = "Bechamél" },/*11*/
                new Ingrediente { Nome = "Azeite" },/*12*/
                new Ingrediente { Nome = "Óleo" },/*13*/
                new Ingrediente { Nome = "Pimenta preta" },/*14*/
                new Ingrediente { Nome = "Sal" },/*15*/
                new Ingrediente { Nome = "Gengibre" },/*16*/
                new Ingrediente { Nome = "Tomilho" },/*17*/
                new Ingrediente { Nome = "Alecrim" },/*18*/
                new Ingrediente { Nome = "Bacalhau" },/*19*/
                new Ingrediente { Nome = "Ovo" },/*20*/
                new Ingrediente { Nome = "Salsa" },/*21*/
                new Ingrediente { Nome = "Azeitona" },/*22*/
                new Ingrediente { Nome = "Chispe" },/*23*/
                new Ingrediente { Nome = "Orelha de Porco" },/*24*/
                new Ingrediente { Nome = "Entrecosto de Porco" },/*25*/
                new Ingrediente { Nome = "Carne de Vaca" },/*26*/
                new Ingrediente { Nome = "Chouriço de Carne" },/*27*/
                new Ingrediente { Nome = "Farinheira" },/*28*/
                new Ingrediente { Nome = "Chouriço de Sangue" },/*29*/
                new Ingrediente { Nome = "Morcela" },/*30*/
                new Ingrediente { Nome = "Arroz" },/*31*/
                new Ingrediente { Nome = "Lombardo" },/*32*/
                new Ingrediente { Nome = "Couve" },/*33*/
                new Ingrediente { Nome = "Nabo" },/*34*/
                new Ingrediente { Nome = "Cenoura" },/*35*/
                new Ingrediente { Nome = "Feijão Branco" },/*36*/
                new Ingrediente { Nome = "Açúcar em Pó" },/*37*/
                new Ingrediente { Nome = "Açúcar" },/*38*/
                new Ingrediente { Nome = "Massa Folhada" },/*39*/
                new Ingrediente { Nome = "Farinha" },/*40*/
                new Ingrediente { Nome = "Natas" },/*41*/
                new Ingrediente { Nome = "Limão" },/*42*/
                new Ingrediente { Nome = "Canela" },/*43*/
                new Ingrediente { Nome = "Água" }, /*44*/
                new Ingrediente { Nome = "Chá Preto" }, /*45*/
                new Ingrediente { Nome = "Gelo" }, /*46*/
                new Ingrediente { Nome = "Cominhos" }, /*47*/
                new Ingrediente { Nome = "Gengibre" }, /*48*/
                new Ingrediente { Nome = "Manteiga" }, /*49*/
                new Ingrediente { Nome = "Molho de Caril" }, /*50*/
                new Ingrediente { Nome = "Molho de Tomate" }, /*51*/
                new Ingrediente { Nome = "Coentros" }, /*52*/
                new Ingrediente { Nome = "Carne de Borrego" }, /*53*/
			};
            ingredientes.ForEach(i => context.Ingredientes.Add(i));
            context.SaveChanges();

            var origens = new List<Origem>
            {
				new Origem { Nome = "Mediterrânica" },
				new Origem { Nome = "Africana" },
				new Origem { Nome = "Indiana" },
				new Origem { Nome = "Tailandesa" },
                new Origem { Nome = "Chinesa" },
                new Origem { Nome = "Portuguesa" },
                new Origem { Nome = "Tailandesa" },
			};
            origens.ForEach(o => context.Origens.Add(o));
            context.SaveChanges();

            var custos = new List<Custo>
            {
				new Custo { Nome = "Barato" },
				new Custo { Nome = "Médio" },
				new Custo { Nome = "Caro" }
			};
            custos.ForEach(o => context.Custos.Add(o));
            context.SaveChanges();

            var dificuldades = new List<Dificuldade>
            {
				new Dificuldade { Nome = "Fácil" },
				new Dificuldade { Nome = "Médio" },
				new Dificuldade { Nome = "Difícil" }
			};
            dificuldades.ForEach(o => context.Dificuldades.Add(o));
            context.SaveChanges();

            var tipos = new List<Tipo>
            {
				new Tipo { Nome = "Vegetariano" },
				new Tipo { Nome = "Carne" },
				new Tipo { Nome = "Peixe" },
				new Tipo { Nome = "Sobremesa" },
                new Tipo { Nome = "Bebidas" }


			};
            tipos.ForEach(x => context.Tipos.Add(x));
            context.SaveChanges();

            var utilizadores = new List<Utilizador>
            {
				new Utilizador { Nome = "Sergio", Tipo = Utilizador.ADMIN },
				new Utilizador { Nome = "Samuel", Tipo = Utilizador.NORMAL },
                new Utilizador { Nome = "Vitor", Tipo = Utilizador.NORMAL }
			};
            WebSecurity.CreateUserAndAccount("Sergio", "1234");
            WebSecurity.CreateUserAndAccount("Samuel", "1234");
            WebSecurity.CreateUserAndAccount("Vitor", "1234");
            utilizadores.ForEach(x => context.Utilizadores.Add(x));
            context.SaveChanges();

            var receitas = new List<Receita>
            {
				new Receita { 
					Titulo = "Ice Tea de Limão",
					Descricao = "Uma refrescante bebida de verão.",
					Duracao = 5,
					TipoId = 5,
					CustoId = 1,
					DificuldadeId = 1,
					UtilizadorId = 3,
					OrigemId = 1,
					Etapas = new List<Etapa> {
						new Etapa {
							Titulo = "Prepare os ingredientes",
							Numero = 1,
							Descricao = "Os ingredientes são simples , mas as proporções são críticas. Por cada 2 quartos de água, iremos usar 3/4 de copo (150 g) sugar, 60 mL de sumo de limão, e dois sacos de chá verde. ",
							ReceitaId = 1,
							Imagem = "~/Content/img/Icetea1.png",
						},
                        						new Etapa {
							Titulo = "Aqueça",
							Numero = 2,
							Descricao = "Aqueça a água na panela até ferver.",
							ReceitaId = 1,
							Imagem = "~/Content/img/Icetea2.png",
						},
                        						new Etapa {
							Titulo = "Junte o chá",
							Numero = 3,
							Descricao = "Junte os dois sacos de chá e remova-os do calor.",
							ReceitaId = 1,
							Imagem = "~/Content/img/Icetea3.png",
						},
                        						new Etapa {
							Titulo = "Adicione sumo de limão e açúcar",
							Numero = 4,
							Descricao = "Quando a água se tornar homogénea , remova os sacos de chá e adicione o sumo de limão e açúcar. Mexer até o açúcar dissolver totalmente.",
							ReceitaId = 1,
							Imagem = "~/Content/img/Icetea4.png",
						},
                                           						new Etapa {
							Titulo = "Sirva",
							Numero = 5,
							Descricao = "Refrigerar e servir.",
							ReceitaId = 1,
							Imagem = "~/Content/img/Iceteafinal.png",
					}
                    }
				},
                new Receita { 
					Titulo = "Almôndegas de Borrego",
					Descricao = "Receita familiar de Almôndegas de Borrego com Caril",
					Duracao = 30,
					TipoId = 2,
					CustoId = 1,
					DificuldadeId = 2,
					UtilizadorId = 3,
					OrigemId = 3,
					Etapas = new List<Etapa> {
						new Etapa {
							Titulo = "Prepare a taça",
							Numero = 1,
							Descricao = "Numa taça grande, adicione sal, a carne de borrego, cominhos e gengibre, misture. Com mãos molhadas role em pequenas bolas.",
							ReceitaId = 2,
							Imagem = "~/Content/img/almondegas1.png",
						} ,
                        						new Etapa {
							Titulo = "Para a frigideira",
							Numero = 2,
							Descricao = "Numa frigideira grande, a lume médio, derreta a manteiga e aqueça levemente as almôndegas, virando a cada 2-3 minutos.",
							ReceitaId = 2,
							Imagem = "~/Content/img/almondegas2.png",
						} ,
                        						new Etapa {
							Titulo = "Frite o Alho",
							Numero = 3,
							Descricao = "Usando a mesma frigideira (Adicione mais manteiga se necessário), frite o alho até ficar dourado.",
							ReceitaId = 2,
							Imagem = "~/Content/img/almondegas3.png",
						} ,
                        						new Etapa {
							Titulo = "Adicione o caril",
							Numero = 4,
							Descricao = "Adicione o caril, misture e frite durante um minute. Adicione água de vez enquando.",
							ReceitaId = 2,
							Imagem = "~/Content/img/almondegas4.png",
						} ,
                        						new Etapa {
							Titulo = "Adicione o molho de tomate",
							Numero = 5,
							Descricao = "Adicione o molho de tomate, vaze, e deixe o molho a ferver, depois cubra durante 10 minutos.",
							ReceitaId = 2,
							Imagem = "~/Content/img/almondegas5.png",
						} ,
                        						new Etapa {
							Titulo = "Junte com as almôndegas",
							Numero = 6,
							Descricao = "Adicione as almôndegas e deixe a cozinhar durante 5 minutos.",
							ReceitaId = 2,
							Imagem = "~/Content/img/almondegas6.png",
						} ,
                        						new Etapa {
							Titulo = "Acabe e sirva com arroz",
							Numero = 7,
							Descricao = "Sirva com arroz e outros acompanhamentos á sua preferência.",
							ReceitaId = 2,
							Imagem = "~/Content/img/almondegasfinal.png",
						} ,
					}
                },
                new Receita { 
					Titulo = "Arroz de Marisco",
					Descricao = "Deliciosa Lasanha de Frango.",
					Duracao = 30,
					TipoId = 1,
					CustoId = 1,
					DificuldadeId = 1,
					UtilizadorId = 2,
					OrigemId = 1,
					Etapas = new List<Etapa> {
						new Etapa {
							Titulo = "Juntar massa ao tomate",
							Numero = 1,
							Descricao = "Juntar a massa ao tomate, sem cozinhar, tudo cru.",
							ReceitaId = 1,
							Imagem = "~/Content/img/comida7.jpg",
						} 
					}
                },
                new Receita { 
					Titulo = "Tarte de maça",
					Descricao = "Deliciosa Lasanha de Frango.",
					Duracao = 30,
					TipoId = 1,
					CustoId = 1,
					DificuldadeId = 1,
					UtilizadorId = 2,
					OrigemId = 1,
					Etapas = new List<Etapa> {
						new Etapa {
							Titulo = "Juntar massa ao tomate",
							Numero = 1,
							Descricao = "Juntar a massa ao tomate, sem cozinhar, tudo cru.",
							ReceitaId = 1,
							Imagem = "~/Content/img/noimg.png",
						} 
					}
                },
                new Receita { 
					Titulo = "Pizza",
					Descricao = "Deliciosa Lasanha de Frango.",
					Duracao = 30,
					TipoId = 1,
					CustoId = 1,
					DificuldadeId = 1,
					UtilizadorId = 2,
					OrigemId = 1,
					Etapas = new List<Etapa> {
						new Etapa {
							Titulo = "Juntar massa ao tomate",
							Numero = 1,
							Descricao = "Juntar a massa ao tomate, sem cozinhar, tudo cru.",
							ReceitaId = 1,
							Imagem = "~/Content/img/comida7.jpg",
						} 
					}
                },
			
             new Receita { 
					Titulo = "Bacalhau à brás",
					Descricao = "Deliciosa receita de bacalhau à Brás.",
					Duracao = 45,
					TipoId = 3,
					CustoId = 2,
					DificuldadeId = 2,
					UtilizadorId = 3,
					OrigemId = 6,
					Etapas = new List<Etapa> {
						new Etapa {
							Titulo = "Prepare o bacalhau",
							Numero = 1,
							Descricao = "Escorra e lave o bacalhau. Limpe-o das peles e espinhas e desfio-o em tiras finas.Reserve.",
							ReceitaId = 6,
							Imagem = "~/Content/img/etapa1bacalhau.png",
						}, 
                       new Etapa {
							Titulo = "Prepare as batatas",
							Numero = 2,
							Descricao = "Descasque as batatas, lave-as e corte-as em palha à mão com uma faca bem afiada ou com um aparelho próprio.",
							ReceitaId = 6,
							Imagem = "~/Content/img/etapa2bacalhau.png",
						}, 
                        new Etapa {
							Titulo = "Frite as batatas",
							Numero = 3,
							Descricao = "Frite-as poucas de cada vez, em azeite fervente. Reserve-as espalhadas numa travessa forrada com papel absorvente.",
							ReceitaId = 6,
							Imagem = "~/Content/img/etapa3bacalhau.png",
						}, 
                         new Etapa {
							Titulo = "Leve ao lume",
							Numero = 4,
							Descricao = "Mude um pouco do azeite para uma frigideira larga antiaderente e leve ao lume com os dentes de alho descascados e pisados. Rejeite-os quando começarem a alourar.",
							ReceitaId = 6,
							Imagem = "~/Content/img/etapa4bacalhau.png",
						}, 
                          new Etapa {
							Titulo = "Prepare as cebolas",
							Numero = 5,
							Descricao = "Descasque as cebolas e corte-as em meias luas. Deite na frigideira e refogue muito rapidamente, mexendo. ",
							ReceitaId = 6,
							Imagem = "~/Content/img/etapa5bacalhau.png",
						}, 
                            new Etapa {
							Titulo = "Junte o bacalhau",
							Numero = 6,
							Descricao = "Nesta altura, junte o bacalhau que reservou e cozinhe um pouco mais.",
							ReceitaId = 6,
							Imagem = "~/Content/img/etapa6bacalhau.png",
						}, 
                            new Etapa {
							Titulo = "Junte as batatas",
							Numero = 7,
							Descricao = "Adicione as batatas e envola de novo todo o preparado.",
							ReceitaId = 6,
							Imagem = "~/Content/img/etapa7bacalhau.png",
						},

                            new Etapa {
							Titulo = "Bata os ovos",
							Numero = 8,
							Descricao = "Bata os ovos numa tigela e tempere com sal e pimenta acabada de moer. Deite a gemada na frigideira.",
							ReceitaId = 6,
							Imagem = "~/Content/img/etapa8bacalhau.png",
                        },
                            new Etapa {
							Titulo = "Envolver",
							Numero = 9,
							Descricao = "Envolva tudo com uma espátula, sem deixar cozinhar demasiado.",
							ReceitaId = 6,
							Imagem = "~/Content/img/etapa9bacalhau.png",
                        },
                            new Etapa {
							Titulo = "A salsa e azeitonas",
							Numero = 10,
							Descricao = "Polvilhe com salsa picada. Mude para um prato de servir e decore com azeitonas pretas.",
							ReceitaId = 6,
							Imagem = "~/Content/img/etapa10bacalhau.png",
                        },
                            new Etapa {
							Titulo = "E voilá",
							Numero = 11,
							Descricao = "Pronto a servir e bon apetit!",
							ReceitaId = 6,
							Imagem = "~/Content/img/Etapafinalbacalhau.png",
						}
                    
					}
                },

                  new Receita { 
					Titulo = "Cozido à Portuguesa",
					Descricao = "Deliciosa receita de Cozido à portuguesa.",
					Duracao = 60,
					TipoId = 2,
					CustoId = 2,
					DificuldadeId = 2,
					UtilizadorId = 3,
					OrigemId = 6,
					Etapas = new List<Etapa> {
						new Etapa {
							Titulo = "Prepare o porco",
							Numero = 1,
							Descricao = "Raspe e lave o chispe e a orelha de porco. Junte o entrecosto e tempere com bastante sal. Aguarde umas horas. Lave de novo e deixe em água fria, 30 minutos, caso precise perder o excesso de sal. Leve ao lume, em água fervente, as carnes preparadas, a carne de vaca e o chouriço lavado.",
							ReceitaId = 7,
							Imagem = "~/Content/img/Cozido1.png",
                                },
						new Etapa {
							Titulo = "Cozinhe o feijão",
							Numero = 2,
							Descricao = "Coza,à parte o feijão branco, o qual foi previamente demolhado. Tempere com sal, só no final da cozedura.",
							ReceitaId = 7,
							Imagem = "~/Content/img/Cozido2.png",
                                },
                        new Etapa {
							Titulo = "Escorra",
							Numero = 3,
							Descricao = "Escorra o feijão, deite-o numa tigela e misture com um pouco do caldo das carnes. Reserve.",
							ReceitaId = 7,
							Imagem = "~/Content/img/Cozido3.png",
                                },
                         new Etapa {
							Titulo = "Lave a farinheira",
							Numero = 4,
							Descricao = "Lave e pique a farinheira, o chouriço de sangue e a morcela.",
							ReceitaId = 7,
							Imagem = "~/Content/img/Cozido4.png",
                                },
                         new Etapa {
							Titulo = "Enchidos ao lume",
							Numero = 5,
							Descricao = "Leve todos os enchidos ao lume, numa panela, quando as carnes ficarem quase prontas.",
							ReceitaId = 7,
							Imagem = "~/Content/img/Cozido5.png",
                                },
                         new Etapa {
							Titulo = "Junte arroz",
							Numero = 6,
							Descricao = "Junte também o arroz, colocado dentro de uma bola de alumínio própria para o efeito.",
							ReceitaId = 7,
							Imagem = "~/Content/img/Cozido6.png",
                                },
                          new Etapa {
							Titulo = "Mude as carnes",
							Numero = 7,
							Descricao = "Mude as carnes e os enchidos para um recipiente fundo e regue com uma concha de caldo. Retire também o arroz.",
							ReceitaId = 7,
							Imagem = "~/Content/img/Cozido7.png",
                                },
                         new Etapa {
							Titulo = "Prepare os legumes",
							Numero = 8,
							Descricao = "Lave e corte os legumes aos pedaços. junte mais água ao caldo se necessário. Já fervente, junte cenouras e nabos, depois as couves e,por fim, as batatas sem casca. Tape e deixe cozinhar. Retifique o sal.",
							ReceitaId = 7,
							Imagem = "~/Content/img/Cozido8.png",
                                },
                         new Etapa {
							Titulo = "Enforme o arroz",
							Numero = 9,
							Descricao = "Enforme o arroz em pequenas tijelas e disponha-o no centro de um prato de servir aquecido.",
							ReceitaId = 7,
							Imagem = "~/Content/img/Cozido9.png",
                                },
                         new Etapa {
							Titulo = "Termine",
							Numero = 10,
							Descricao = "Disponha em redor as carnes cortadas, os legumes, colheradas de feijão e os enchidos às rodelas. Pode servir o caldo fervente deitado sobre fatias de pão e folhas de hortelã.",
							ReceitaId = 7,
							Imagem = "~/Content/img/Cozido10.png",
                                },
                          new Etapa {
							Titulo = "E pronto!",
							Numero = 11,
							Descricao = "Sirva e bom proveito.",
							ReceitaId = 7,
							Imagem = "~/Content/img/CozidoPtfinal.png",
                                
						}, 

                    }

                  },
                                  new Receita { 
					Titulo = "Pastéis de Nata",
					Descricao = "Pastéis de nata tradicionais.",
					Duracao = 20,
					TipoId = 4,
					CustoId = 1,
					DificuldadeId = 1,
					UtilizadorId = 3,
					OrigemId = 6,
					Etapas = new List<Etapa> {
						new Etapa {
							Titulo = "Estenda a massa",
							Numero = 1,
							Descricao = "Estenda a massa folhada e com ela forre pequenas formas lisas pressionando no fundo e à volta com as pontas dos dedos humedecidos em água.Reserve.",
							ReceitaId = 8,
							Imagem = "~/Content/img/Pasteldenata.png",
						} ,
						new Etapa {
							Titulo = "Misture",
							Numero = 2,
							Descricao = "Misture muito bem, sem bater, as gemas com o açúcar e a farinha. Junte a nata e raspa de limão e misture de novo. Leve ao lume, sem parar de mexer, até levantar fervura. Retire do lume e deixe amornar. Deite o creme nas formas sem encher demasiado.",
							ReceitaId = 8,
							Imagem = "~/Content/img/Pasteldenata.png",
						} ,
                        						new Etapa {
							Titulo = "Leve ao forno",
							Numero = 3,
							Descricao = "Coloque as formas num tabuleiro e leve ao forno quente pré-aquecido a cerca de 250ºC até a massa cozer e  folhar e o creme ficar bem alourado. Desenforme os pastéis e sirva-os mornos polvilhados com açúcar em pó e canela.",
							ReceitaId = 8,
							Imagem = "~/Content/img/Pasteldenata.png",
						} 
					}
                },
            }
            ;
            receitas.ForEach(x => context.Receitas.Add(x));
            context.SaveChanges();

            var ingredientesReceita = new List<IngredienteReceita>
            {
				new IngredienteReceita {
					Quantidade = "Meio Galão",
					IngredienteId = 44,
					ReceitaId = 1
				},
               new IngredienteReceita {
					Quantidade = "2 sacos",
					IngredienteId = 45,
					ReceitaId = 1
				},
               new IngredienteReceita {
					Quantidade = "150 g",
					IngredienteId = 38,
					ReceitaId = 1
				},
              new IngredienteReceita {
					Quantidade = "60 ml de sumo",
					IngredienteId = 42,
					ReceitaId = 1
				},
              new IngredienteReceita {
					Quantidade = "Vários cubos",
					IngredienteId = 46,
					ReceitaId = 1
				},

                new IngredienteReceita {
					Quantidade = "600 g",
					IngredienteId = 19,
					ReceitaId = 6
				},
                new IngredienteReceita {
					Quantidade = "700 g",
					IngredienteId = 2,
					ReceitaId = 6
				},
                 new IngredienteReceita {
					Quantidade = "30 ml",
					IngredienteId = 12,
					ReceitaId = 6
				},
                 new IngredienteReceita {
					Quantidade = "3 dentes",
					IngredienteId = 4,
					ReceitaId = 6
				},
                 new IngredienteReceita {
					Quantidade = "2",
					IngredienteId = 5,
					ReceitaId = 6
				},
                new IngredienteReceita {
					Quantidade = "5",
					IngredienteId = 20,
					ReceitaId = 6
				},
                new IngredienteReceita {
					Quantidade = "1 pitada",
					IngredienteId = 15,
					ReceitaId = 6
				},
                new IngredienteReceita {
					Quantidade = "1 pitada",
					IngredienteId = 21,
					ReceitaId = 6
				},
                new IngredienteReceita {
					Quantidade = "Algumas",
					IngredienteId = 22,
					ReceitaId = 6
				},

                                new IngredienteReceita {
					Quantidade = "1",
					IngredienteId = 23,
					ReceitaId = 7
				},
                                new IngredienteReceita {
					Quantidade = "1",
					IngredienteId = 24,
					ReceitaId = 7
				},
                                new IngredienteReceita {
					Quantidade = "400 g",
					IngredienteId = 25,
					ReceitaId = 7
				},
                                new IngredienteReceita {
					Quantidade = "várias pitadas",
					IngredienteId = 15,
					ReceitaId = 7
				},
                                new IngredienteReceita {
					Quantidade = "750 g",
					IngredienteId = 26,
					ReceitaId = 7
				},
                                new IngredienteReceita {
					Quantidade = "1",
					IngredienteId = 27,
					ReceitaId = 7
				},
                                new IngredienteReceita {
					Quantidade = "4 dl",
					IngredienteId = 36,
					ReceitaId = 7
				},
                                new IngredienteReceita {
					Quantidade = "1",
					IngredienteId = 28,
					ReceitaId = 7
				},
                                new IngredienteReceita {
					Quantidade = "1",
					IngredienteId = 29,
					ReceitaId = 7
				},
                                new IngredienteReceita {
					Quantidade = "1",
					IngredienteId = 30,
					ReceitaId = 7
				},
                                new IngredienteReceita {
					Quantidade = "250 g",
					IngredienteId = 31,
					ReceitaId = 7
				},
                                new IngredienteReceita {
					Quantidade = "1",
					IngredienteId = 32,
					ReceitaId = 7
				},
                                new IngredienteReceita {
					Quantidade = "1",
					IngredienteId = 33,
					ReceitaId = 7
				},
                                 new IngredienteReceita {
					Quantidade = "2",
					IngredienteId = 34,
					ReceitaId = 7
				},
                                  new IngredienteReceita {
					Quantidade = "400 g",
					IngredienteId = 35,
					ReceitaId = 7
				},
                                 new IngredienteReceita {
					Quantidade = "600 g",
					IngredienteId = 2,
					ReceitaId = 7
				},

                   new IngredienteReceita {
					Quantidade = "1 embalagem",
					IngredienteId = 39,
					ReceitaId = 8
				},
                                                 new IngredienteReceita {
					Quantidade = "8",
					IngredienteId = 20,
					ReceitaId = 8
				},
                                                                 new IngredienteReceita {
					Quantidade = "200 g",
					IngredienteId = 38,
					ReceitaId = 8
				},
                                                                 new IngredienteReceita {
					Quantidade = "1 c",
					IngredienteId = 40,
					ReceitaId = 8
				},
                                                                 new IngredienteReceita {
					Quantidade = "500 ml",
					IngredienteId = 41,
					ReceitaId = 8
				},

                                                                 new IngredienteReceita {
					Quantidade = "casca",
					IngredienteId = 42,
					ReceitaId = 8
				},

                                                                 new IngredienteReceita {
					Quantidade = "1",
					IngredienteId = 37,
					ReceitaId = 8
				},
                                                                 new IngredienteReceita {
					Quantidade = "1",
					IngredienteId = 43,
					ReceitaId = 8
				},

                                                                 new IngredienteReceita {
					Quantidade = "1 kg",
					IngredienteId = 53,
					ReceitaId = 2
				},
                                                                 new IngredienteReceita {
					Quantidade = "1 colher",
					IngredienteId = 47,
					ReceitaId = 2
				},

                                                                 new IngredienteReceita {
					Quantidade = "1 colher",
					IngredienteId = 48,
					ReceitaId = 2
				},
                                                                 new IngredienteReceita {
					Quantidade = "1 colher",
					IngredienteId = 15,
					ReceitaId = 2
				},
                                                                 new IngredienteReceita {
					Quantidade = "2 colheres",
					IngredienteId = 49,
					ReceitaId = 2
				},
                                                                 new IngredienteReceita {
					Quantidade = "1",
					IngredienteId = 5,
					ReceitaId = 2
				},
                                                                                 new IngredienteReceita {
					Quantidade = "4",
					IngredienteId = 4,
					ReceitaId = 2
				},
                                                                                 new IngredienteReceita {
					Quantidade = "4 colheres",
					IngredienteId = 44,
					ReceitaId = 2
				},
                                                                                 new IngredienteReceita {
					Quantidade = "2 colheres",
					IngredienteId = 51,
					ReceitaId = 2
				},
                                                                                 new IngredienteReceita {
					Quantidade = "meio copo",
					IngredienteId = 52,
					ReceitaId = 2
				},



			};
            ingredientesReceita.ForEach(x => context.IngredientesReceita.Add(x));
            context.SaveChanges();

            var comentarios = new List<Comentario>
            {
				new Comentario {
					Texto = "Já experimentei, é muito boa!",
					Data = DateTime.Now,
					ReceitaId = 2,
					UtilizadorId = 2
				},
                new Comentario {
					Texto = "Uma maravilha culinária!",
					Data = DateTime.Now,
					ReceitaId = 6,
					UtilizadorId = 2
				},
				new Comentario {
					Texto = "É ok.",
					Data = DateTime.Now,
					ReceitaId = 1,
					UtilizadorId = 1
				},
                new Comentario {
					Texto = "Muito bom!",
					Data = DateTime.Now,
					ReceitaId = 7,
					UtilizadorId = 1
				},
                                new Comentario {
					Texto = "Podia ser mais completa...",
					Data = DateTime.Now,
					ReceitaId = 8,
					UtilizadorId = 1
				}
			};
            comentarios.ForEach(x => context.Comentarios.Add(x));
            context.SaveChanges();

            var classificacoes = new List<Classificacao>
            {
				new Classificacao {
					Valor = 4,
					UtilizadorId = 2,
					ReceitaId = 2
				},
                				new Classificacao {
					Valor = 3,
					UtilizadorId = 2,
					ReceitaId = 1
				},
                new Classificacao {
					Valor = 5,
					UtilizadorId = 2,
					ReceitaId = 6
				},
                                new Classificacao {
					Valor = 5,
					UtilizadorId = 1,
					ReceitaId = 7
				},
                                              new Classificacao {
					Valor = 4,
					UtilizadorId = 2,
					ReceitaId = 7
				},

                                                             new Classificacao {
					Valor = 3,
					UtilizadorId = 1,
					ReceitaId = 8
				}
			};
            classificacoes.ForEach(x => context.Classificacoes.Add(x));
            context.SaveChanges();
        }
    }
}