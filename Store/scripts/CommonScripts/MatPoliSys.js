// function SingleWall(xirx, yiry, faseleDRCH, heightMSD1, widthMSD1, halatSD1,tedaKolSatheDastresi, pipeStock, anbarPaye,anbarGHechi) {
function getdarPolySys(widthMO, heightMO,
    faseleDRCH, andazePol, anbarKeshabi,
    anbarPaye, anbarGHechi, anbarPlayt, anbarPlaytPeleDar) {


    var anbarPlaytPeleDarD = anbarPlaytPeleDar;

    var anbarKeshabi300 = anbarKeshabi[0];
    var anbarKeshabi250 = anbarKeshabi[1];
    var anbarKeshabi130 = anbarKeshabi[2];
    var anbarKeshabi100 = anbarKeshabi[3];
    var anbarKeshabi75 = anbarKeshabi[4];

    var anbarPlayt300 = anbarPlayt[0];
    var anbarPlayt250 = anbarPlayt[1];
    var anbarPlayt130 = anbarPlayt[2];
    var anbarPlayt100 = anbarPlayt[3];
    var anbarPlayt75 = anbarPlayt[4];

    var anbarPaye400 = anbarPaye[0];
    var anbarPaye300 = anbarPaye[1];
    var anbarPaye200 = anbarPaye[2];
    var anbarPaye100 = anbarPaye[3];
    var anbarPaye50 = anbarPaye[4];

    var anbarGHechi250 = anbarGHechi[0];
    var anbarGHechi300 = anbarGHechi[1];

    anbarPlaytPeleDarDR = anbarPlaytPeleDarD;

    anbarKeshabi300R = anbarKeshabi300;
    anbarKeshabi250R = anbarKeshabi250;
    anbarKeshabi130R = anbarKeshabi130;
    anbarKeshabi100R = anbarKeshabi100;
    anbarKeshabi75R = anbarKeshabi75;


    anbarPlayt300R = anbarPlayt300;
    anbarPlayt250R = anbarPlayt250;
    anbarPlayt130R = anbarPlayt130;
    anbarPlayt100R = anbarPlayt100;
    anbarPlayt75R = anbarPlayt75;


    anbarGHechi250R = anbarGHechi250;
    anbarGHechi300R = anbarGHechi300;


    anbarPaye400R = anbarPaye400;
    anbarPaye300R = anbarPaye300;
    anbarPaye200R = anbarPaye200;
    anbarPaye100R = anbarPaye100;
    anbarPaye50R = anbarPaye50;


    var finalAlert = "موجودی کافی نیست";
    var resultMsg = true;

    var heightM = heightMO;


    var heightC = (heightM * 100);


    var tedadErtefa = parseInt(heightC / 200);
    var firstHeight = 0;
    var finalLoopTol = 0;
    var arrayAndazeTolha = [];
    // hesab tol hame
    if (widthMO === 75) {
        if (anbarKeshabi75 >= (((tedadErtefa + 1) * 8) + 12)) {
            anbarKeshabi75 = anbarKeshabi75 - (((tedadErtefa + 1) * 8) + 12);
        } else {
            resultMsg = false
        }
    }
    else if (widthMO === 100) {
        if (anbarKeshabi100 >= (((tedadErtefa + 1) * 8) + 12)) {
            anbarKeshabi100 = anbarKeshabi100 - (((tedadErtefa + 1) * 8) + 12);
        } else {
            resultMsg = false
        }
    }
    else if (widthMO === 130) {
        if (anbarKeshabi130 >= (((tedadErtefa + 1) * 8) + 12)) {
            anbarKeshabi130 = anbarKeshabi130 - (((tedadErtefa + 1) * 8) + 12);
        } else {
            resultMsg = false
        }
    }
    else if (widthMO === 250) {
        if (anbarKeshabi250 >= (((tedadErtefa + 1) * 8) + 12)) {
            anbarKeshabi250 = anbarKeshabi250 - (((tedadErtefa + 1) * 8) + 12);
        } else {
            resultMsg = false
        }
    }
    else if (widthMO === 300) {
        if (anbarKeshabi300 >= (((tedadErtefa + 1) * 8) + 12)) {
            anbarKeshabi300 = anbarKeshabi300 - (((tedadErtefa + 1) * 8) + 12);
        } else {
            resultMsg = false
        }
    }

    // hesab brase tol
    if (widthMO === 75) {

        var ted = 0;
        ted = parseInt(heightC / 250);
        if (anbarGHechi250 >= ted * 4) {
            anbarGHechi250 = anbarGHechi250 - (ted * 4);
        } else {
            resultMsg = false
        }
    }
    else if (widthMO === 100) {


        if (anbarGHechi250 >= tedadErtefa * 4) {
            anbarGHechi250 = anbarGHechi250 - (tedadErtefa * 4);
        } else {
            resultMsg = false
        }
    }
    else if (widthMO === 130) {

        if (anbarGHechi250 >= tedadErtefa * 4) {
            anbarGHechi250 = anbarGHechi250 - (tedadErtefa * 4);
        } else {
            resultMsg = false
        }
    }
    else if (widthMO === 250) {
        if (anbarGHechi300 >= tedadErtefa * 4) {
            anbarGHechi300 = anbarGHechi300 - (tedadErtefa * 4);
        } else {
            resultMsg = false
        }
    }
    else if (widthMO === 300) {
        if (anbarGHechi300 >= tedadErtefa * 4) {
            anbarGHechi300 = anbarGHechi300 - (tedadErtefa * 4);
        } else {
            resultMsg = false
        }
    }

    // hesab brase arz
    if (faseleDRCH === 75) {

        var ted = 0;
        ted = parseInt(heightC / 250);
        if (anbarGHechi250 >= ted * 4) {
            anbarGHechi250 = anbarGHechi250 - (ted * 4);
        } else {
            resultMsg = false
        }
    }
    else if (faseleDRCH === 100) {


        if (anbarGHechi250 >= tedadErtefa * 4) {
            anbarGHechi250 = anbarGHechi250 - (tedadErtefa * 4);
        } else {
            resultMsg = false
        }
    }
    else if (faseleDRCH === 130) {

        if (anbarGHechi250 >= tedadErtefa * 4) {
            anbarGHechi250 = anbarGHechi250 - (tedadErtefa * 4);
        } else {
            resultMsg = false
        }
    }
    else if (faseleDRCH === 250) {
        if (anbarGHechi300 >= tedadErtefa * 4) {
            anbarGHechi300 = anbarGHechi300 - (tedadErtefa * 4);
        } else {
            resultMsg = false
        }
    }
    else if (faseleDRCH === 300) {
        if (anbarGHechi300 >= tedadErtefa * 4) {
            anbarGHechi300 = anbarGHechi300 - (tedadErtefa * 4);
        } else {
            resultMsg = false
        }
    }


    //hesab kardan paye ha hame ta pol

    for (j = 0; j < 8; j++) {
        for (ib = heightC + 200; ib > 0;) {
            if (ib === 350) {
                if (anbarPaye300 > 0) {
                    anbarPaye300 = anbarPaye300 - 1;
                    ib = ib - 300;
                    if (anbarPaye50 > 0) {
                        anbarPaye50 = anbarPaye50 - 1;
                        ib = ib - 50;

                    } else if (anbarPaye100 > 0) {
                        anbarPaye100 = anbarPaye100 - 1;
                        ib = ib - 100;

                    } else if (anbarPaye200 > 0) {
                        anbarPaye200 = anbarPaye200 - 1;
                        ib = ib - 200;

                    } else if (anbarPaye300 > 0) {
                        anbarPaye300 = anbarPaye300 - 1;
                        ib = ib - 300;

                    } else if (anbarPaye400 > 0) {
                        anbarPaye400 = anbarPaye400 - 1;
                        ib = ib - 400;

                    } else {
                        resultMsg = false


                    }


                }
                else if (anbarPaye200 > 0) {

                    anbarPaye200 = anbarPaye200 - 1;
                    ib = ib - 200;

                    if (anbarPaye100 > 0) {

                        anbarPaye100 = anbarPaye100 - 1;
                        ib = ib - 100;
                        if (anbarPaye50 > 0) {
                            anbarPaye50 = anbarPaye50 - 1;
                            ib = ib - 50;

                        } else if (anbarPaye100 > 0) {
                            anbarPaye100 = anbarPaye100 - 1;
                            ib = ib - 100;

                        } else if (anbarPaye200 > 0) {
                            anbarPaye200 = anbarPaye200 - 1;
                            ib = ib - 200;

                        } else if (anbarPaye400 > 0) {
                            anbarPaye400 = anbarPaye400 - 1;
                            ib = ib - 400;

                        } else {
                            resultMsg = false


                        }


                    }
                    else if (anbarPaye200 > 0) {
                        anbarPaye200 = anbarPaye200 - 1;
                        ib = ib - 200;

                    }
                    else if (anbarPaye400 > 0) {
                        anbarPaye400 = anbarPaye400 - 1;
                        ib = ib - 400;

                    } else if (anbarPaye50 > 0) {
                        anbarPaye50 = anbarPaye50 - 1;
                        ib = ib - 50;
                        if (anbarPaye50 > 0) {
                            anbarPaye50 = anbarPaye50 - 1;
                            ib = ib - 50;
                            if (anbarPaye50 > 0) {
                                anbarPaye50 = anbarPaye50 - 1;
                                ib = ib - 50;

                            } else {
                                resultMsg = false


                            }

                        } else {
                            resultMsg = false


                        }

                    } else {
                        resultMsg = false


                    }


                }
                else if (anbarPaye100 > 0) {
                    anbarPaye100 = anbarPaye100 - 1;
                    ib = ib - 100;
                    if (anbarPaye100 > 0) {
                        anbarPaye100 = anbarPaye100 - 1;
                        ib = ib - 100;
                        if (anbarPaye100 > 0) {
                            anbarPaye100 = anbarPaye100 - 1;
                            ib = ib - 100;
                            if (anbarPaye50 > 0) {
                                anbarPaye50 = anbarPaye50 - 1;
                                ib = ib - 50;

                            } else if (anbarPaye100 > 0) {
                                anbarPaye100 = anbarPaye100 - 1;
                                ib = ib - 50;

                            }

                            else {
                                resultMsg = false


                            }
                        }
                        else if (anbarPaye50 > 0) {
                            anbarPaye50 = anbarPaye50 - 1;
                            ib = ib - 50;
                            if (anbarPaye50 > 0) {
                                anbarPaye50 = anbarPaye50 - 1;
                                ib = ib - 50;
                                if (anbarPaye50 > 0) {
                                    anbarPaye50 = anbarPaye50 - 1;
                                    ib = ib - 50;
                                } else {
                                    resultMsg = false


                                }
                            } else {
                                resultMsg = false


                            }
                        } else {
                            resultMsg = false


                        }
                    }
                    else if (anbarPaye50 > 0) {
                        anbarPaye50 = anbarPaye50 - 1;
                        ib = ib - 50;
                        if (anbarPaye50 > 0) {
                            anbarPaye50 = anbarPaye50 - 1;
                            ib = ib - 50;
                            if (anbarPaye50 > 0) {
                                anbarPaye50 = anbarPaye50 - 1;
                                ib = ib - 50;
                                if (anbarPaye50 > 0) {
                                    anbarPaye50 = anbarPaye50 - 1;
                                    ib = ib - 50;
                                    if (anbarPaye50 > 0) {
                                        anbarPaye50 = anbarPaye50 - 1;
                                        ib = ib - 50;
                                    }

                                    else {
                                        resultMsg = false


                                    }
                                }

                                else {
                                    resultMsg = false


                                }
                            }

                            else {
                                resultMsg = false


                            }
                        }

                        else {
                            resultMsg = false


                        }
                    }

                    else {
                        resultMsg = false


                    }
                }
                else if (anbarPaye50 > 0) {
                    anbarPaye50 = anbarPaye50 - 1;
                    ib = ib - 50;
                    if (anbarPaye50 > 0) {
                        anbarPaye50 = anbarPaye50 - 1;
                        ib = ib - 50;
                        if (anbarPaye50 > 0) {
                            anbarPaye50 = anbarPaye50 - 1;
                            ib = ib - 50;
                            if (anbarPaye50 > 0) {
                                anbarPaye50 = anbarPaye50 - 1;
                                ib = ib - 50;
                                if (anbarPaye50 > 0) {
                                    anbarPaye50 = anbarPaye50 - 1;
                                    ib = ib - 50;
                                    if (anbarPaye50 > 0) {
                                        anbarPaye50 = anbarPaye50 - 1;
                                        ib = ib - 50;
                                    }

                                    else {
                                        resultMsg = false


                                    }
                                }

                                else {
                                    resultMsg = false


                                }
                            }

                            else {
                                resultMsg = false


                            }
                        }

                        else {
                            resultMsg = false


                        }
                    }

                    else {
                        resultMsg = false


                    }
                }
                else if (anbarPaye400 > 0) {
                    anbarPaye400 = anbarPaye400 - 1;
                    ib = ib - 400;

                }
                else {
                    resultMsg = false


                }

            }
            else if (ib === 300) {
                if (anbarPaye300 > 0) {
                    anbarPaye300 = anbarPaye300 - 1;
                    ib = ib - 300;

                }
                else if (anbarPaye200 > 0) {
                    anbarPaye200 = anbarPaye200 - 1;
                    ib = ib - 200;
                    if (anbarPaye100 > 0) {
                        anbarPaye100 = anbarPaye100 - 1;
                        ib = ib - 100;

                    }
                    else if (anbarPaye50 > 0) {
                        anbarPaye50 = anbarPaye50 - 1;
                        ib = ib - 50;
                        if (anbarPaye50 > 0) {
                            anbarPaye50 = anbarPaye50 - 1;
                            ib = ib - 50;

                        } else if (anbarPaye200 > 0) {
                            anbarPaye200 = anbarPaye200 - 1;
                            ib = ib - 200;

                        }
                        else if (anbarPaye400 > 0) {
                            anbarPaye400 = anbarPaye400 - 1;
                            ib = ib - 400;

                        }
                        else {
                            resultMsg = false


                        }
                    }
                    else if (anbarPaye200 > 0) {
                        anbarPaye200 = anbarPaye200 - 1;
                        ib = ib - 200;

                    }
                    else if (anbarPaye400 > 0) {
                        anbarPaye400 = anbarPaye400 - 1;
                        ib = ib - 400;

                    } else {
                        resultMsg = false


                    }
                }
                else if (anbarPaye100 > 0) {
                    anbarPaye100 = anbarPaye100 - 1;
                    ib = ib - 100;
                    if (anbarPaye100 > 0) {
                        anbarPaye100 = anbarPaye100 - 1;
                        ib = ib - 100;
                        if (anbarPaye100 > 0) {
                            anbarPaye100 = anbarPaye100 - 1;
                            ib = ib - 100;

                        } else if (anbarPaye50 > 0) {
                            anbarPaye50 = anbarPaye50 - 1;
                            ib = ib - 50;
                            if (anbarPaye50 > 0) {
                                anbarPaye50 = anbarPaye50 - 1;
                                ib = ib - 50;

                            } else {
                                resultMsg = false


                            }
                        } else {
                            resultMsg = false


                        }
                    }
                    else if (anbarPaye50 > 0) {
                        anbarPaye50 = anbarPaye50 - 1;
                        ib = ib - 50;
                        if (anbarPaye50 > 0) {
                            anbarPaye50 = anbarPaye50 - 1;
                            ib = ib - 50;
                            if (anbarPaye50 > 0) {
                                anbarPaye50 = anbarPaye50 - 1;
                                ib = ib - 50;
                                if (anbarPaye50 > 0) {
                                    anbarPaye50 = anbarPaye50 - 1;
                                    ib = ib - 50;

                                } else {
                                    resultMsg = false


                                }
                            } else {
                                resultMsg = false


                            }
                        } else {
                            resultMsg = false


                        }
                    } else {
                        resultMsg = false


                    }


                }
                else if (anbarPaye50 > 0) {
                    anbarPaye50 = anbarPaye50 - 1;
                    ib = ib - 50;
                    if (anbarPaye50 > 0) {
                        anbarPaye50 = anbarPaye50 - 1;
                        ib = ib - 50;
                        if (anbarPaye50 > 0) {
                            anbarPaye50 = anbarPaye50 - 1;
                            ib = ib - 50;
                            if (anbarPaye50 > 0) {
                                anbarPaye50 = anbarPaye50 - 1;
                                ib = ib - 50;
                                if (anbarPaye50 > 0) {
                                    anbarPaye50 = anbarPaye50 - 1;
                                    ib = ib - 50;
                                    if (anbarPaye50 > 0) {
                                        anbarPaye50 = anbarPaye50 - 1;
                                        ib = ib - 50;

                                    } else {
                                        resultMsg = false


                                    }
                                } else {
                                    resultMsg = false


                                }
                            } else {
                                resultMsg = false


                            }
                        } else {
                            resultMsg = false


                        }
                    } else {
                        resultMsg = false


                    }
                }

                else if (anbarPaye400 > 0) {
                    anbarPay400 = anbarPaye400 - 1;
                    ib = ib - 400;

                }
                else {
                    resultMsg = false


                }

            }
            else if (ib === 250) {
                if (anbarPaye200 > 0) {
                    anbarPaye200 = anbarPaye200 - 1;
                    ib = ib - 200;
                    if (anbarPaye50 > 0) {
                        anbarPaye50 = anbarPaye50 - 1;
                        ib = ib - 50;

                    } else if (anbarPaye100 > 0) {
                        anbarPaye100 = anbarPaye100 - 1;
                        ib = ib - 100;

                    } else if (anbarPaye200 > 0) {
                        anbarPaye200 = anbarPaye200 - 1;
                        ib = ib - 200;

                    } else {
                        resultMsg = false


                    }


                }
                else if (anbarPaye100 > 0) {
                    anbarPaye100 = anbarPaye100 - 1;
                    ib = ib - 100;


                    if (anbarPaye100 > 0) {
                        anbarPaye100 = anbarPaye100 - 1;
                        ib = ib - 100;
                        if (anbarPaye50 > 0) {
                            anbarPaye50 = anbarPaye50 - 1;
                            ib = ib - 50;

                        } else if (anbarPaye100 > 0) {
                            anbarPaye100 = anbarPaye100 - 1;
                            ib = ib - 100;

                        } else {
                            resultMsg = false


                        }
                    } else if (anbarPaye50 > 0) {
                        anbarPaye50 = anbarPaye50 - 1;
                        ib = ib - 50;
                        if (anbarPaye50 > 0) {
                            anbarPaye50 = anbarPaye50 - 1;
                            ib = ib - 50;

                        } else {
                            resultMsg = false


                        }
                    } else {
                        resultMsg = false


                    }


                }
                else if (anbarPaye50 > 0) {
                    anbarPaye50 = anbarPaye50 - 1;
                    ib = ib - 50;
                    if (anbarPaye50 > 0) {
                        anbarPaye50 = anbarPaye50 - 1;
                        ib = ib - 50;
                        if (anbarPaye50 > 0) {
                            anbarPaye50 = anbarPaye50 - 1;
                            ib = ib - 50;
                            if (anbarPaye50 > 0) {
                                anbarPaye50 = anbarPaye50 - 1;
                                ib = ib - 50;
                                if (anbarPaye50 > 0) {
                                    anbarPaye50 = anbarPaye50 - 1;
                                    ib = ib - 50;

                                }

                                else {
                                    resultMsg = false


                                }
                            }

                            else {
                                resultMsg = false


                            }
                        }

                        else {
                            resultMsg = false


                        }
                    }

                    else {
                        resultMsg = false


                    }
                }
                else if (anbarPaye300 > 0) {
                    anbarPaye300 = anbarPaye300 - 1;
                    ib = ib - 300;

                }
                else if (anbarPaye400 > 0) {
                    anbarPaye400 = anbarPaye400 - 1;
                    ib = ib - 400;

                }


                else {
                    resultMsg = false


                }
            }
            else if (ib === 200) {
                if (anbarPaye200 > 0) {
                    anbarPaye200 = anbarPaye200 - 1;
                    ib = ib - 200;

                }
                else if (anbarPaye100 > 0) {
                    anbarPaye100 = anbarPaye100 - 1;
                    ib = ib - 100;
                    if (anbarPaye100 > 0) {
                        anbarPaye100 = anbarPaye100 - 1;
                        ib = ib - 100;

                    } else if (anbarPaye50 > 0) {
                        anbarPaye50 = anbarPaye50 - 1;
                        ib = ib - 50;
                        if (anbarPaye50 > 0) {
                            anbarPaye50 = anbarPaye50 - 1;
                            ib = ib - 50;

                        } else {
                            resultMsg = false


                        }
                    } else {
                        resultMsg = false


                    }
                }
                else if (anbarPaye50 > 0) {
                    anbarPaye50 = anbarPaye50 - 1;
                    ib = ib - 50;
                    if (anbarPaye50 > 0) {
                        anbarPaye50 = anbarPaye50 - 1;
                        ib = ib - 50;
                        if (anbarPaye50 > 0) {
                            anbarPaye50 = anbarPaye50 - 1;
                            ib = ib - 50;
                            if (anbarPaye50 > 0) {
                                anbarPaye50 = anbarPaye50 - 1;
                                ib = ib - 50;

                            }


                            else {
                                resultMsg = false


                            }
                        }


                        else {
                            resultMsg = false


                        }
                    }


                    else {
                        resultMsg = false


                    }
                }
                else if (anbarPaye300 > 0) {
                    anbarPaye300 = anbarPaye300 - 1;
                    ib = ib - 300;

                }
                else if (anbarPaye400 > 0) {
                    anbarPaye400 = anbarPaye400 - 1;
                    ib = ib - 400;

                }


                else {
                    resultMsg = false


                }


            }
            else if (ib === 150) {
                if (anbarPaye100 > 0) {
                    anbarPaye100 = anbarPaye100 - 1;
                    ib = ib - 100;
                    if (anbarPaye50 > 0) {
                        anbarPaye50 = anbarPaye50 - 1;
                        ib = ib - 50;

                    } else {
                        resultMsg = false


                    }
                }
                else if (anbarPaye50 > 0) {
                    anbarPaye50 = anbarPaye50 - 1;
                    ib = ib - 50;
                    if (anbarPaye50 > 0) {
                        anbarPaye50 = anbarPaye50 - 1;
                        ib = ib - 50;
                        if (anbarPaye50 > 0) {
                            anbarPaye50 = anbarPaye50 - 1;
                            ib = ib - 50;

                        } else {
                            resultMsg = false


                        }
                    } else {
                        resultMsg = false


                    }
                }
                else if (anbarPaye200 > 0) {
                    anbarPaye200 = anbarPaye200 - 1;
                    ib = ib - 200;

                }
                else if (anbarPaye300 > 0) {
                    anbarPaye300 = anbarPaye300 - 1;
                    ib = ib - 300;

                }
                else if (anbarPaye400 > 0) {
                    anbarPaye400 = anbarPaye400 - 1;
                    ib = ib - 400;

                }

                else {
                    resultMsg = false


                }

            }
            else if (ib === 100) {
                if (anbarPaye100 > 0) {
                    anbarPaye100 = anbarPaye100 - 1;
                    ib = ib - 100;

                }
                else if (anbarPaye50 > 0) {
                    anbarPaye50 = anbarPaye50 - 1;
                    ib = ib - 50;
                    if (anbarPaye50 > 0) {
                        anbarPaye50 = anbarPaye50 - 1;
                        ib = ib - 50;

                    } else {
                        resultMsg = false


                    }
                }
                else if (anbarPaye200 > 0) {
                    anbarPaye200 = anbarPaye200 - 1;
                    ib = ib - 200;

                }
                else if (anbarPaye300 > 0) {
                    anbarPaye300 = anbarPaye300 - 1;
                    ib = ib - 300;

                }
                else if (anbarPaye400 > 0) {
                    anbarPaye400 = anbarPaye400 - 1;
                    ib = ib - 400;

                }
                else {
                    resultMsg = false


                }

            }
            else if (ib === 50) {


                if (anbarPaye50 > 0) {
                    anbarPaye50 = anbarPaye50 - 1;
                    ib = ib - 50;

                }
                else if (anbarPaye100 > 0) {
                    anbarPaye100 = anbarPaye100 - 1;
                    ib = ib - 100;

                }
                else if (anbarPaye200 > 0) {
                    anbarPaye200 = anbarPaye200 - 1;
                    ib = ib - 200;

                }
                else if (anbarPaye300 > 0) {
                    anbarPaye300 = anbarPaye300 - 1;
                    ib = ib - 300;

                }
                else if (anbarPaye400 > 0) {
                    anbarPaye400 = anbarPaye400 - 1;
                    ib = ib - 400;

                }


            }
            else {

                if (anbarPaye400 > 0) {
                    anbarPaye400 = anbarPaye400 - 1;
                    ib = ib - 400;


                }
                else if (anbarPaye300 > 0) {
                    anbarPaye300 = anbarPaye300 - 1;
                    ib = ib - 300;

                }
                else if (anbarPaye200 > 0) {
                    anbarPaye200 = anbarPaye200 - 1;
                    ib = ib - 200;

                }
                else if (anbarPaye100 > 0) {
                    anbarPaye100 = anbarPaye100 - 1;
                    ib = ib - 100;

                }
                else if (anbarPaye50 > 0) {
                    anbarPaye50 = anbarPaye50 - 1;
                    ib = ib - 50;

                }
                else {
                    resultMsg = false


                }
            }

        }

    }

    // hesab kardan arz
    if (faseleDRCH === 75) {
        if (anbarKeshabi75 >= (((tedadErtefa + 1) * 8) + 4)) {
            anbarKeshabi75 = anbarKeshabi75 - (((tedadErtefa + 1) * 8) + 4);
        } else {
            resultMsg = false
        }
    }
    else if (faseleDRCH === 100) {
        if (anbarKeshabi100 >= (((tedadErtefa + 1) * 8) + 4)) {
            anbarKeshabi100 = anbarKeshabi100 - (((tedadErtefa + 1) * 8) + 4);
        } else {
            resultMsg = false
        }
    }
    else if (faseleDRCH === 130) {
        if (anbarKeshabi130 >= (((tedadErtefa + 1) * 8) + 4)) {
            anbarKeshabi130 = anbarKeshabi130 - (((tedadErtefa + 1) * 8) + 4);
        } else {
            resultMsg = false
        }
    }
    else if (faseleDRCH === 250) {
        if (anbarKeshabi250 >= (((tedadErtefa + 1) * 8) + 4)) {
            anbarKeshabi250 = anbarKeshabi250 - (((tedadErtefa + 1) * 8) + 4);
        } else {
            resultMsg = false
        }
    }
    else if (faseleDRCH === 300) {
        if (anbarKeshabi300 >= (((tedadErtefa + 1) * 8) + 4)) {
            anbarKeshabi300 = anbarKeshabi300 - (((tedadErtefa + 1) * 8) + 4);
        } else {
            resultMsg = false
        }
    }


    //    hesab pol
    if (andazePol === 1) {
        if (anbarKeshabi300 >= 6) {
            anbarKeshabi300 = anbarKeshabi300 - 6
        } else {
            resultMsg = false
        }
        if (faseleDRCH === 75) {

            if (anbarPlayt300 >= 4) {
                anbarPlayt300 = anbarPlayt300 - 4;

            } else {
                resultMsg = false
            }
        }
        else if (faseleDRCH === 100) {

            if (anbarPlayt300 >= 6) {
                anbarPlayt300 = anbarPlayt300 - 6;

            } else {
                resultMsg = false
            }
        }
        else if (faseleDRCH === 130) {

            if (anbarPlayt300 >= 8) {
                anbarPlayt300 = anbarPlayt300 - 8;

            } else {
                resultMsg = false
            }
        }
        else if (faseleDRCH === 250) {

            if (anbarPlayt300 >= 14) {
                anbarPlayt300 = anbarPlayt300 - 14;

            } else {
                resultMsg = false
            }
        }
        else if (faseleDRCH === 300) {

            if (anbarPlayt300 >= 18) {
                anbarPlayt300 = anbarPlayt300 - 18;

            } else {
                resultMsg = false
            }
        }
    }
    else if (andazePol === 2) {
        if (anbarKeshabi300 >= 12) {
            anbarKeshabi300 = anbarKeshabi300 - 12;
        } else {
            resultMsg = false
        }
        if (faseleDRCH === 75) {
            if (anbarKeshabi75 >= 2) {

                anbarKeshabi75 = anbarKeshabi75 - 2;

            } else {
                resultMsg = false
            }
            if (anbarPlayt300 >= 8) {
                anbarPlayt300 = anbarPlayt300 - 8;

            } else {
                resultMsg = false
            }
        }
        else if (faseleDRCH === 100) {
            if (anbarKeshabi100 >= 2) {

                anbarKeshabi100 = anbarKeshabi100 - 2;

            } else {
                resultMsg = false
            }
            if (anbarPlayt300 >= 9) {
                anbarPlayt300 = anbarPlayt300 - 9;

            } else {
                resultMsg = false
            }
        }
        else if (faseleDRCH === 130) {
            if (anbarKeshabi130 >= 2) {

                anbarKeshabi130 = anbarKeshabi130 - 2;

            } else {
                resultMsg = false
            }
            if (anbarPlayt300 >= 12) {
                anbarPlayt300 = anbarPlayt300 - 12;

            } else {
                resultMsg = false
            }
        }
        else if (faseleDRCH === 250) {
            if (anbarKeshabi250 >= 2) {

                anbarKeshabi250 = anbarKeshabi250 - 2;

            } else {
                resultMsg = false
            }
            if (anbarPlayt300 >= 21) {
                anbarPlayt300 = anbarPlayt300 - 21;

            } else {
                resultMsg = false
            }
        }
        else if (faseleDRCH === 300) {
            if (anbarKeshabi300 >= 2) {

                anbarKeshabi300 = anbarKeshabi300 - 2;

            } else {
                resultMsg = false
            }
            if (anbarPlayt300 >= 27) {
                anbarPlayt300 = anbarPlayt300 - 27;

            } else {
                resultMsg = false
            }
        }
    }
    //

    if (faseleDRCH === 75) {
        if (widthMO === 75) {
            if (anbarPlayt75 >= (tedadErtefa + 1) * 1) {
                anbarPlayt75 = anbarPlayt75 - ((tedadErtefa + 1) * 1);

            } else {
                resultMsg = false
            }


        }
        else if (widthMO === 100) {
            if (anbarPlayt100 >= (tedadErtefa + 1) * 1) {
                anbarPlayt100 = anbarPlayt100 - ((tedadErtefa + 1) * 1);

            } else {
                resultMsg = false
            }
        }
        else if (widthMO === 130) {
            if (anbarPlayt130 >= (tedadErtefa + 1) * 1) {
                anbarPlayt130 = anbarPlayt130 - ((tedadErtefa + 1) * 1);

            } else {
                resultMsg = false
            }
        }
        else if (widthMO === 250) {
            if (anbarPlayt250 >= (tedadErtefa + 1) * 1) {
                anbarPlayt250 = anbarPlayt250 - ((tedadErtefa + 1) * 1);

            } else {
                resultMsg = false
            }
        }
        else if (widthMO === 300) {
            if (anbarPlayt300 >= (tedadErtefa + 1) * 1) {
                anbarPlayt300 = anbarPlayt300 - ((tedadErtefa + 1) * 1);

            } else {
                resultMsg = false
            }
        }

    }
    else if (faseleDRCH === 100) {
        if (widthMO === 75) {
            if (anbarPlayt75 >= (tedadErtefa + 1) * 2) {
                anbarPlayt75 = anbarPlayt75 - ((tedadErtefa + 1) * 2);

            } else {
                resultMsg = false
            }
        }
        else if (widthMO === 100) {
            if (anbarPlayt100 >= (tedadErtefa + 1) * 2) {
                anbarPlayt100 = anbarPlayt100 - ((tedadErtefa + 1) * 2);

            } else {
                resultMsg = false
            }
        }
        else if (widthMO === 130) {
            if (anbarPlayt130 >= (tedadErtefa + 1) * 2) {
                anbarPlayt130 = anbarPlayt130 - ((tedadErtefa + 1) * 2);

            } else {
                resultMsg = false
            }
        }
        else if (widthMO === 250) {
            if (anbarPlayt250 >= (tedadErtefa + 1) * 2) {
                anbarPlayt250 = anbarPlayt250 - ((tedadErtefa + 1) * 2);

            } else {
                resultMsg = false
            }
        }
        else if (widthMO === 300) {
            if (anbarPlayt300 >= (tedadErtefa + 1) * 2) {
                anbarPlayt300 = anbarPlayt300 - ((tedadErtefa + 1) * 2);

            } else {
                resultMsg = false
            }
        }

    }
    else if (faseleDRCH === 130) {
        if (widthMO === 75) {
            if (anbarPlayt75 >= (tedadErtefa + 1) * 3) {
                anbarPlayt75 = anbarPlayt75 - ((tedadErtefa + 1) * 3);

            } else {
                resultMsg = false
            }
        }
        else if (widthMO === 100) {
            if (anbarPlayt100 >= (tedadErtefa + 1) * 3) {
                anbarPlayt100 = anbarPlayt100 - ((tedadErtefa + 1) * 3);

            } else {
                resultMsg = false
            }
        }
        else if (widthMO === 130) {
            if (anbarPlayt130 >= (tedadErtefa + 1) * 3) {
                anbarPlayt130 = anbarPlayt130 - ((tedadErtefa + 1) * 3);

            } else {
                resultMsg = false
            }
        }
        else if (widthMO === 250) {
            if (anbarPlayt250 >= (tedadErtefa + 1) * 3) {
                anbarPlayt250 = anbarPlayt250 - ((tedadErtefa + 1) * 3);

            } else {
                resultMsg = false
            }
        }
        else if (widthMO === 300) {
            if (anbarPlayt300 >= (tedadErtefa + 1) * 3) {
                anbarPlayt300 = anbarPlayt300 - ((tedadErtefa + 1) * 3);

            } else {
                resultMsg = false
            }
        }

    }
    else if (faseleDRCH === 250) {
        if (widthMO === 75) {
            if (anbarPlayt75 >= (tedadErtefa + 1) * 6) {
                anbarPlayt75 = anbarPlayt75 - ((tedadErtefa + 1) * 6);

            } else {
                resultMsg = false
            }
        }
        else if (widthMO === 100) {
            if (anbarPlayt100 >= (tedadErtefa + 1) * 6) {
                anbarPlayt100 = anbarPlayt100 - ((tedadErtefa + 1) * 6);

            } else {
                resultMsg = false
            }
        }
        else if (widthMO === 130) {
            if (anbarPlayt130 >= (tedadErtefa + 1) * 6) {
                anbarPlayt130 = anbarPlayt130 - ((tedadErtefa + 1) * 6);

            } else {
                resultMsg = false
            }
        }
        else if (widthMO === 250) {
            if (anbarPlayt250 >= (tedadErtefa + 1) * 6) {
                anbarPlayt250 = anbarPlayt250 - ((tedadErtefa + 1) * 6);

            } else {
                resultMsg = false
            }
        }
        else if (widthMO === 300) {
            if (anbarPlayt300 >= (tedadErtefa + 1) * 6) {
                anbarPlayt300 = anbarPlayt300 - ((tedadErtefa + 1) * 6);

            } else {
                resultMsg = false
            }
        }

    }
    else if (faseleDRCH === 300) {
        if (widthMO === 75) {
            if (anbarPlayt75 >= (tedadErtefa + 1) * 8) {
                anbarPlayt75 = anbarPlayt75 - (tedadErtefa + 1) * 8;

            } else {
                resultMsg = false
            }
        }
        else if (widthMO === 100) {
            if (anbarPlayt100 >= (tedadErtefa + 1) * 8) {
                anbarPlayt100 = anbarPlayt100 - ((tedadErtefa + 1) * 8);

            } else {
                resultMsg = false
            }
        }
        else if (widthMO === 130) {
            if (anbarPlayt130 >= (tedadErtefa + 1) * 8) {
                anbarPlayt130 = anbarPlayt130 - ((tedadErtefa + 1) * 8);

            } else {
                resultMsg = false
            }
        }
        else if (widthMO === 250) {
            if (anbarPlayt250 >= (tedadErtefa + 1) * 8) {
                anbarPlayt250 = anbarPlayt250 - ((tedadErtefa + 1) * 8);

            } else {
                resultMsg = false
            }
        }
        else if (widthMO === 300) {
            if (anbarPlayt300 >= (tedadErtefa + 1) * 8) {
                anbarPlayt300 = anbarPlayt300 - ((tedadErtefa + 1) * 8);

            } else {
                resultMsg = false
            }
        }

    }

    if (anbarPlaytPeleDarD >= tedadErtefa + 1) {
        anbarPlaytPeleDarD = anbarPlaytPeleDarD - (tedadErtefa + 1);

    } else {
        resultMsg = false

    }

    //alert("تعداد کشابی 0.75" + "   " + (anbarKeshabi75R - anbarKeshabi75))
    //alert("تعداد کشابی 1 متر " + "   " + (anbarKeshabi100R - anbarKeshabi100))
    //alert("تعداد کشابی 1.3 متر" + "   " + (anbarKeshabi130R - anbarKeshabi130))
    //alert("تعداد کشابی 2.5 متر" + "   " + (anbarKeshabi250R - anbarKeshabi250))
    //alert("تعداد کشابی 3 متر" + "   " + (anbarKeshabi300R - anbarKeshabi300))

    //alert("تعداد پلیت 0.75" + "   " + (anbarPlayt75R - anbarPlayt75))
    //alert("تعداد پلیت 1 متر " + "   " + (anbarPlayt100R - anbarPlayt100))
    //alert("تعداد پلیت 1.3 متر" + "   " + (anbarPlayt130R - anbarPlayt130))
    //alert("تعداد پلیت 2.5 متر" + "   " + (anbarPlayt250R - anbarPlayt250))
    //alert("تعداد پلیت 3 متر" + "   " + (anbarPlayt300R - anbarPlayt300))

    //alert("تعداد قیچی 2.5 متر" + "   " + (anbarGHechi250R - anbarGHechi250))
    //alert("تعداد قیچی 3 متر" + "   " + (anbarGHechi300R - anbarGHechi300))


    //alert("تعداد پایه 0.5 متر" + "   " + (anbarPaye50R - anbarPaye50))
    //alert("تعداد پایه 1 متر" + "   " + (anbarPaye100R - anbarPaye100))
    //alert("تعداد پایه 2 متر" + "   " + (anbarPaye200R - anbarPaye200))
    //alert("تعداد پایه 3 متر" + "   " + (anbarPaye300R - anbarPaye300))
    //alert("تعداد پایه 4 متر" + "   " + (anbarPaye400R - anbarPaye400))
    //alert("تعداد پله" + "   " + (anbarPlaytPeleDarDR - anbarPlaytPeleDarD))


    var t = 0;
    if (andazePol === 1) {
        t = 2
    } else if (andazePol === 2) {
        t = 4
    }


    //alert("تعداد یونیت بیم" + "   " + t)


    var keshabi_75 = (anbarKeshabi75R - anbarKeshabi75);
    var keshabi_1 = (anbarKeshabi100R - anbarKeshabi100);
    var keshabi_13 = (anbarKeshabi130R - anbarKeshabi130);
    var keshabi_25 = (anbarKeshabi250R - anbarKeshabi250);
    var keshabi_3 = (anbarKeshabi300R - anbarKeshabi300);


    var plate_75 = (anbarPlayt75R - anbarPlayt75);
    var plate_1 = (anbarPlayt100R - anbarPlayt100);
    var plate_13 = (anbarPlayt130R - anbarPlayt130);
    var plate_25 = (anbarPlayt250R - anbarPlayt250);
    var plate_3 = (anbarPlayt300R - anbarPlayt300);


    var gheychi_25 = (anbarGHechi250R - anbarGHechi250);
    var gheychi_3 = (anbarGHechi300R - anbarGHechi300);


    var paye_50 = (anbarPaye50R - anbarPaye50);
    var paye_1 = (anbarPaye100R - anbarPaye100);
    var paye_2 = (anbarPaye200R - anbarPaye200);
    var paye_3 = (anbarPaye300R - anbarPaye300);
    var paye_4 = (anbarPaye400R - anbarPaye400);
    var pele = (anbarPlaytPeleDarDR - anbarPlaytPeleDarD);




    return [["تعداد کشابی 0.75", keshabi_75],
    ["تعداد کشابی 1 متر", keshabi_1],
    ["تعداد کشابی 1.3 متر", keshabi_13],
    ["تعداد کشابی 2.5 متر", keshabi_25],
    ["تعداد کشابی 3 متر", keshabi_3],
    ["تعداد پلیت 0.75", plate_75],
    ["تعداد پلیت 1 متر", plate_1],
    ["تعداد پلیت 1.3 متر", plate_13],
    ["تعداد پلیت 2.5 متر", plate_25],
    ["تعداد پلیت 3 متر", plate_3],
    ["تعداد قیچی 2.5 متر", gheychi_25],
    ["تعداد قیچی 3 متر", gheychi_3],
    ["تعداد پایه 0.5 متر", paye_50],
    ["تعداد پایه 1 متر", paye_1],
    ["تعداد پایه 2 متر", paye_2],
    ["تعداد پایه 3 متر", paye_3],
    ["تعداد پایه 4 متر", paye_4],
    ["تعداد پله", pele],
    ["تعداد یونیت بیم", t]];


    // for (k = 0; k < tedadErtefa; k++) {
    //     if (anbarKeshabi300>) {
    //
    //     }
    //
    //
    // }


    //    keshabia va playt bra sathe dastresi 4 taraf
    //    az payin playet avalin dahane do ta
}


//
// alert("تعداد لوله چهار فوت" + "   " + (anbar91R - anbar91))
// alert("تعداد لوله پنج فوت" + "   " + (anbar152R - anbar152))
// alert("تعداد لوله شش فوت" + "   " + (anbar182R - anbar182))
// alert("تعداد لوله هشت فوت" + "   " + (anbar243R - anbar243))
// alert("تعداد لوله ده فوت" + "   " + (anbar304R - anbar304))
// alert("تعداد لوله دوازده فوت" + "   " + (anbar365R - anbar365))
// alert("تعداد لوله چهارده فوت" + "   " + (anbar426R - anbar426))
// alert("تعداد لوله شانزده فوت" + "   " + (anbar487R - anbar487))
// alert("تعداد لوله هجده فوت" + "   " + (anbar548R - anbar548))










