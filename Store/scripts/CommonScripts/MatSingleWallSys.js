// function SingleWall(xirx, yiry, faseleDRCH, heightMSD1, widthMSD1, halatSD1,tedaKolSatheDastresi, pipeStock, anbarPaye,anbarGHechi) {
function SingleWallSys(widthMO, heightMO,
                    faseleDRCH, heightMSD1, widthMSD1, halatSD1,
                    tedaKolSatheDastresi, anbarKeshabi,
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

    //اینجا همون موجودیشون کمو زیاد کنیشون تو حساب کتابا متراژ دیگه مشخصه یکیشونو نداشته باشن چی میشه
    var resultMsg = true;

    var finalAlert = "موجودی کافی نیست";


    var widthM = widthMO;
    var heightM = heightMO;


    var widthC = (widthM * 100);
    var heightC = (heightM * 100);


    var tedadErtefa = parseInt(heightC / 200);
    var firstHeight = 0;
    var finalLoopTol = 0;
    var arrayAndazeTolha = [];
    // hesab tol
    for (j = widthC; j > 0;) {


        if (j <= 250 && j > 130) {
            if (j > 130) {

                if (anbarKeshabi250 >= (faseleDRCH.length + 1) * (tedadErtefa + 1)) {
                    anbarKeshabi250 = anbarKeshabi250 - (faseleDRCH.length + 1) * (tedadErtefa + 1);
                    j = j - 250;
                    finalLoopTol = finalLoopTol + 1
                    arrayAndazeTolha.push(250);

                }
                else if (anbarKeshabi300 >= (faseleDRCH.length + 1) * (tedadErtefa + 1)) {
                    anbarKeshabi300 = anbarKeshabi300 - (faseleDRCH.length + 1) * (tedadErtefa + 1);
                    j = j - 300;
                    finalLoopTol = finalLoopTol + 1
                    arrayAndazeTolha.push(300);

                }
                else if (anbarKeshabi130 >= (faseleDRCH.length + 1) * (tedadErtefa + 1)) {
                    anbarKeshabi130 = anbarKeshabi130 - (faseleDRCH.length + 1) * (tedadErtefa + 1);
                    j = j - 130;
                    finalLoopTol = finalLoopTol + 1
                    arrayAndazeTolha.push(130);
                    if (anbarKeshabi130 >= (faseleDRCH.length + 1) * (tedadErtefa + 1)) {
                        anbarKeshabi130 = anbarKeshabi130 - (faseleDRCH.length + 1) * (tedadErtefa + 1);
                        j = j - 130;
                        finalLoopTol = finalLoopTol + 1
                        arrayAndazeTolha.push(130);
                    }
                    else {
                        resultMsg = false;


                    }
                }

                else {
                    resultMsg = false;


                }
            }
            else {
                if (anbarKeshabi130 >= (faseleDRCH.length + 1) * (tedadErtefa + 1)) {
                    anbarKeshabi130 = anbarKeshabi130 - (faseleDRCH.length + 1) * (tedadErtefa + 1);
                    j = j - 130;
                    finalLoopTol = finalLoopTol + 1
                    arrayAndazeTolha.push(130);

                }
                else if (anbarKeshabi75 >= (faseleDRCH.length + 1) * (tedadErtefa + 1)) {
                    anbarKeshabi75 = anbarKeshabi75 - (faseleDRCH.length + 1) * (tedadErtefa + 1);
                    j = j - 75;
                    finalLoopTol = finalLoopTol + 1
                    arrayAndazeTolha.push(75);
                    if (anbarKeshabi75 >= (faseleDRCH.length + 1) * (tedadErtefa + 1)) {
                        anbarKeshabi75 = anbarKeshabi75 - (faseleDRCH.length + 1) * (tedadErtefa + 1);
                        j = j - 75;
                        finalLoopTol = finalLoopTol + 1
                        arrayAndazeTolha.push(75);

                    } else {
                        resultMsg = false;


                    }
                }

                else {
                    resultMsg = false;


                }

            }

        }
        else if (j <= 130 && j > 100) {

            if (anbarKeshabi130 >= (faseleDRCH.length + 1) * (tedadErtefa + 1)) {
                anbarKeshabi130 = anbarKeshabi130 - (faseleDRCH.length + 1) * (tedadErtefa + 1);
                j = j - 130;
                finalLoopTol = finalLoopTol + 1
                arrayAndazeTolha.push(130);
            }
            else if (anbarKeshabi100 >= (faseleDRCH.length + 1) * (tedadErtefa + 1)) {
                anbarKeshabi100 = anbarKeshabi100 - (faseleDRCH.length + 1) * (tedadErtefa + 1);
                j = j - 130;
                finalLoopTol = finalLoopTol + 1
                arrayAndazeTolha.push(130);
                if (anbarKeshabi75 >= (faseleDRCH.length + 1) * (tedadErtefa + 1)) {
                    anbarKeshabi75 = anbarKeshabi75 - (faseleDRCH.length + 1) * (tedadErtefa + 1);
                    j = j - 75;
                    finalLoopTol = finalLoopTol + 1
                    arrayAndazeTolha.push(75);
                }
                else {
                    resultMsg = false;


                }
            }

            else {
                resultMsg = false;


            }
        }
        else if (j <= 100 && j >= 1) {

            if (anbarKeshabi100 >= (faseleDRCH.length + 1) * (tedadErtefa + 1)) {
                anbarKeshabi100 = anbarKeshabi100 - (faseleDRCH.length + 1) * (tedadErtefa + 1);
                j = j - 130;
                finalLoopTol = finalLoopTol + 1
                arrayAndazeTolha.push(130);
            }
            else if (anbarKeshabi75 >= (faseleDRCH.length + 1) * (tedadErtefa + 1)) {
                anbarKeshabi75 = anbarKeshabi75 - (faseleDRCH.length + 1) * (tedadErtefa + 1);
                j = j - 75;
                finalLoopTol = finalLoopTol + 1
                arrayAndazeTolha.push(75);
            }
            else {
                resultMsg = false;


            }
        }
        else {

            if (anbarKeshabi300 >= (faseleDRCH.length + 1) * (tedadErtefa + 1)) {
                anbarKeshabi300 = anbarKeshabi300 - (faseleDRCH.length + 1) * (tedadErtefa + 1);
                j = j - 300;

                finalLoopTol = finalLoopTol + 1
                firstHeight = 300;
                arrayAndazeTolha.push(300);


            }
            else if (anbarKeshabi250 >= (faseleDRCH.length + 1) * (tedadErtefa + 1)) {
                anbarKeshabi250 = anbarKeshabi250 - (faseleDRCH.length + 1) * (tedadErtefa + 1);
                j = j - 250;
                firstHeight = 250;

                finalLoopTol = finalLoopTol + 1
                arrayAndazeTolha.push(250);


            }
            else if (anbarKeshabi130 >= (faseleDRCH.length + 1) * (tedadErtefa + 1)) {
                anbarKeshabi130 = anbarKeshabi130 - (faseleDRCH.length + 1) * (tedadErtefa + 1);
                j = j - 130;
                firstHeight = 130;

                finalLoopTol = finalLoopTol + 1
                arrayAndazeTolha.push(130);


            }
            else if (anbarKeshabi100 >= (faseleDRCH.length + 1) * (tedadErtefa + 1)) {
                anbarKeshabi100 = anbarKeshabi100 - (faseleDRCH.length + 1) * (tedadErtefa + 1);
                j = j - 100;
                firstHeight = 100;

                finalLoopTol = finalLoopTol + 1
                arrayAndazeTolha.push(100);

            }
            else if (anbarKeshabi75 >= (faseleDRCH.length + 1) * (tedadErtefa + 1)) {
                anbarKeshabi75 = anbarKeshabi75 - (faseleDRCH.length + 1) * (tedadErtefa + 1);
                j = j - 75;
                firstHeight = 75;

                finalLoopTol = finalLoopTol + 1
                arrayAndazeTolha.push(75);


            }
            else {
                resultMsg = false;
            }
        }

    }


    // hesab brase tol
    for (i = 0; i < finalLoopTol - 1; i = i + 3) {


        if (arrayAndazeTolha[i] === 300) {
            if (anbarGHechi300 > tedadErtefa) {
                anbarGHechi300 = anbarGHechi300 - tedadErtefa;


            } else {
                resultMsg = false;
            }

        }
        else if (arrayAndazeTolha[i] === 250) {
            if (anbarGHechi300 > tedadErtefa) {
                anbarGHechi300 = anbarGHechi300 - tedadErtefa;


            } else {
                resultMsg = false;
            }

        }
        else if (arrayAndazeTolha[i] === 130) {
            if (anbarGHechi250 > tedadErtefa) {
                anbarGHechi250 = anbarGHechi250 - tedadErtefa;


            } else {
                resultMsg = false;
            }

        }
        else if (arrayAndazeTolha[i] === 100) {

            if (anbarGHechi250 > tedadErtefa) {
                anbarGHechi250 = anbarGHechi250 - tedadErtefa;


            } else {
                resultMsg = false;
            }
        }
        else if (arrayAndazeTolha[i] === 75) {

            var tedad75T = parseInt(heightC / 250);

            if (anbarGHechi250 > tedad75T) {
                anbarGHechi250 = anbarGHechi250 - tedad75T;

            } else {
                resultMsg = false;
            }


        }

    }

    // hesab brase arz
    for (i = 0; i < faseleDRCH.length; i++) {


        for (j = 0; j < finalLoopTol; j = j + 3) {


            if (faseleDRCH[i] === 300) {

                if (anbarGHechi300 > tedadErtefa) {
                    anbarGHechi300 = anbarGHechi300 - tedadErtefa;

                } else {
                    resultMsg = false;
                }

            }
            else if (faseleDRCH[i] === 250) {
                if (anbarGHechi300 > tedadErtefa) {
                    anbarGHechi300 = anbarGHechi300 - tedadErtefa;


                } else {
                    resultMsg = false;
                }

            }
            else if (faseleDRCH[i] === 130) {
                if (anbarGHechi250 > tedadErtefa) {
                    anbarGHechi250 = anbarGHechi250 - tedadErtefa;


                } else {
                    resultMsg = false;
                }

            }
            else if (faseleDRCH[i] === 100) {

                if (anbarGHechi250 > tedadErtefa) {
                    anbarGHechi250 = anbarGHechi250 - tedadErtefa;


                } else {
                    resultMsg = false;
                }
            }
            else if (faseleDRCH[i] === 75) {
                var tedad75T = parseInt(heightC / 250);

                if (anbarGHechi250 > tedad75T) {
                    anbarGHechi250 = anbarGHechi250 - tedad75T;

                } else {
                    resultMsg = false;
                }

            }


        }
    }


    //hesab kardan paye ha

    for (ij = 0; ij <= finalLoopTol; ij++) {
        for (j = 0; j <= faseleDRCH.length; j++) {
            for (ib = heightC; ib > 0;) {
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
                            resultMsg = false;


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
                                resultMsg = false;


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
                                    resultMsg = false;


                                }

                            } else {
                                resultMsg = false;


                            }

                        } else {
                            resultMsg = false;


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
                                    resultMsg = false;


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
                                        resultMsg = false;


                                    }
                                } else {
                                    resultMsg = false;


                                }
                            } else {
                                resultMsg = false;


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
                                            resultMsg = false;


                                        }
                                    }

                                    else {
                                        resultMsg = false;


                                    }
                                }

                                else {
                                    resultMsg = false;


                                }
                            }

                            else {
                                resultMsg = false;


                            }
                        }

                        else {
                            resultMsg = false;


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
                                            resultMsg = false;


                                        }
                                    }

                                    else {
                                        resultMsg = false;


                                    }
                                }

                                else {
                                    resultMsg = false;


                                }
                            }

                            else {
                                resultMsg = false;


                            }
                        }

                        else {
                            resultMsg = false;


                        }
                    }
                    else if (anbarPaye400 > 0) {
                        anbarPaye400 = anbarPaye400 - 1;
                        ib = ib - 400;

                    }
                    else {
                        resultMsg = false;


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
                                resultMsg = false;


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
                            resultMsg = false;


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
                                    resultMsg = false;


                                }
                            } else {
                                resultMsg = false;


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
                                        resultMsg = false;


                                    }
                                } else {
                                    resultMsg = false;


                                }
                            } else {
                                resultMsg = false;


                            }
                        } else {
                            resultMsg = false;


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
                                            resultMsg = false;


                                        }
                                    } else {
                                        resultMsg = false;


                                    }
                                } else {
                                    resultMsg = false;


                                }
                            } else {
                                resultMsg = false;


                            }
                        } else {
                            resultMsg = false;


                        }
                    }

                    else if (anbarPaye400 > 0) {
                        anbarPay400 = anbarPaye400 - 1;
                        ib = ib - 400;

                    }
                    else {
                        resultMsg = false;


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
                            resultMsg = false;


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
                                resultMsg = false;


                            }
                        } else if (anbarPaye50 > 0) {
                            anbarPaye50 = anbarPaye50 - 1;
                            ib = ib - 50;
                            if (anbarPaye50 > 0) {
                                anbarPaye50 = anbarPaye50 - 1;
                                ib = ib - 50;

                            } else {
                                resultMsg = false;


                            }
                        } else {
                            resultMsg = false;


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
                                        resultMsg = false;


                                    }
                                }

                                else {
                                    resultMsg = false;


                                }
                            }

                            else {
                                resultMsg = false;


                            }
                        }

                        else {
                            resultMsg = false;


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
                        resultMsg = false;


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
                                resultMsg = false;


                            }
                        } else {
                            resultMsg = false;


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
                                    resultMsg = false;


                                }
                            }


                            else {
                                resultMsg = false;


                            }
                        }


                        else {
                            resultMsg = false;


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
                        resultMsg = false;


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
                            resultMsg = false;


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
                                resultMsg = false;


                            }
                        } else {
                            resultMsg = false;


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
                        resultMsg = false;


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
                            resultMsg = false;


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
                        resultMsg = false;


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
                        resultMsg = false;


                    }
                }

            }

        }
    }


    // hesab kardan arz
    for (ij = 0; ij < faseleDRCH.length; ij++) {
        for (j = 0; j <= finalLoopTol; j++) {

            for (i = 0; i <= tedadErtefa; i++) {

                if (faseleDRCH[ij] === 75) {


                    if (anbarKeshabi75 >=1) {
                        anbarKeshabi75 = anbarKeshabi75 - 1;
                    }
                    else {
                        resultMsg = false;
                    }
                }
                else if (faseleDRCH[ij] === 100) {
                    if (anbarKeshabi100 >=1) {
                        anbarKeshabi100 = anbarKeshabi100 - 1;
                    }
                    else {
                        resultMsg = false;
                    }

                } else if (faseleDRCH[ij] === 130) {
                    if (anbarKeshabi130 >=1) {
                        anbarKeshabi130 = anbarKeshabi130 - 1;
                    }
                    else {
                        resultMsg = false;
                    }


                } else if (faseleDRCH[ij] === 250) {
                    if (anbarKeshabi250 >=1) {
                        anbarKeshabi250 = anbarKeshab250 - 1;
                    }
                    else {
                        resultMsg = false;
                    }

                } else if (faseleDRCH[ij] === 300) {
                    if (anbarKeshabi300 >=1) {
                        anbarKeshabi300 = anbarKeshabi300 - 1;
                    }


                    else {
                        resultMsg = false;


                    }
                }


            }

        }
    }


    //    hesab sathe dastresi
    var ASD = true;
    if (ASD === true) {

        var jameArrayAndazeTolha = 0;
        var jameArrayAndazeTolhaAll = 0;
        var jameArrayAndazeTolhaAllM1 = 0;

        for (i = 0; i < arrayAndazeTolha.length; i++) {
            jameArrayAndazeTolhaAll = jameArrayAndazeTolhaAll + arrayAndazeTolha[i];
            if (i === arrayAndazeTolha.length - 1) {
            } else {

                jameArrayAndazeTolhaAllM1 = jameArrayAndazeTolhaAllM1 + arrayAndazeTolha[i];

            }
        }


        var makanSath = [];

        var widthSD = []


        for (b = 0; b < tedaKolSatheDastresi; b++) {

            widthSD[b] = widthMSD1[b] * 100;

            if (widthSD[b] <= jameArrayAndazeTolhaAll && widthSD[b] >= jameArrayAndazeTolhaAllM1) {

                makanSath[b] = arrayAndazeTolha.length - 1

            }
            else {

                for (i = 0; i < arrayAndazeTolha.length; i++) {


                    if (jameArrayAndazeTolha < widthSD[b] && jameArrayAndazeTolha + arrayAndazeTolha[i + 1] > widthSD[b]) {


                        makanSath[b] = i;
                    }
                    jameArrayAndazeTolha = jameArrayAndazeTolha + arrayAndazeTolha[i];


                }

            }

        }


        for (i = 0; i < tedaKolSatheDastresi; i++) {

            if (firstHeight === 300) {

                if (widthMSD1[0] === 1 || widthMSD1[0] === 2 || widthMSD1[0] === 3) {
                    anbarPlayt300 = anbarPlayt300 + 1
                    if (faseleDRCH[0] === 300) {
                        anbarKeshabi300 = anbarKeshabi300 + 2
                    }
                    else if (faseleDRCH[0] === 250) {
                        anbarKeshabi250 = anbarKeshabi250 + 2
                    }
                    else if (faseleDRCH[0] === 130) {
                        anbarKeshabi130 = anbarKeshabi130 + 2
                    }
                    else if (faseleDRCH[0] === 100) {
                        anbarKeshabi100 = anbarKeshabi100 + 2
                    }
                    else if (faseleDRCH[0] === 75) {
                        anbarKeshabi75 = anbarKeshabi75 + 2
                    }


                    if (arrayAndazeTolha[0] === 300) {
                        anbarKeshabi300 = anbarKeshabi300 + 4
                    }
                    else if (arrayAndazeTolha[0] === 250) {
                        anbarKeshabi250 = anbarKeshabi250 + 4
                    }
                    else if (arrayAndazeTolha[0] === 130) {
                        anbarKeshabi130 = anbarKeshabi130 + 4
                    }
                    else if (arrayAndazeTolha[0] === 100) {
                        anbarKeshabi100 = anbarKeshabi100 + 4
                    }
                    else if (arrayAndazeTolha[0] === 75) {
                        anbarKeshabi75 = anbarKeshabi75 + 4
                    }


                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1
                    } else {
                        resultMsg = false;
                    }


                }

            }
            else if (firstHeight === 250) {
                if (widthMSD1[0] === 1 || widthMSD1[0] === 2 || widthMSD1[0] === 3) {
                    if (faseleDRCH[0] === 300) {
                        anbarKeshabi300 = anbarKeshabi300 + 2
                    }
                    else if (faseleDRCH[0] === 250) {
                        anbarKeshabi250 = anbarKeshabi250 + 2
                    }
                    else if (faseleDRCH[0] === 130) {
                        anbarKeshabi130 = anbarKeshabi130 + 2
                    }
                    else if (faseleDRCH[0] === 100) {
                        anbarKeshabi100 = anbarKeshabi100 + 2
                    }
                    else if (faseleDRCH[0] === 75) {
                        anbarKeshabi75 = anbarKeshabi75 + 2
                    }


                    if (arrayAndazeTolha[0] === 300) {
                        anbarKeshabi300 = anbarKeshabi300 + 4
                    }
                    else if (arrayAndazeTolha[0] === 250) {
                        anbarKeshabi250 = anbarKeshabi250 + 4
                    }
                    else if (arrayAndazeTolha[0] === 130) {
                        anbarKeshabi130 = anbarKeshabi130 + 4
                    }
                    else if (arrayAndazeTolha[0] === 100) {
                        anbarKeshabi100 = anbarKeshabi100 + 4
                    }
                    else if (arrayAndazeTolha[0] === 75) {
                        anbarKeshabi75 = anbarKeshabi75 + 4
                    }
                    anbarPlayt250 = anbarPlayt250 + 1
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1
                    } else {
                        resultMsg = false;
                    }


                }

            }
            else if (firstHeight === 130) {
                if (widthMSD1[0] === 1 || widthMSD1[0] === 2 || widthMSD1[0] === 3) {
                    if (faseleDRCH[0] === 300) {
                        anbarKeshabi300 = anbarKeshabi300 + 2
                    }
                    else if (faseleDRCH[0] === 250) {
                        anbarKeshabi250 = anbarKeshabi250 + 2
                    }
                    else if (faseleDRCH[0] === 130) {
                        anbarKeshabi130 = anbarKeshabi130 + 2
                    }
                    else if (faseleDRCH[0] === 100) {
                        anbarKeshabi100 = anbarKeshabi100 + 2
                    }
                    else if (faseleDRCH[0] === 75) {
                        anbarKeshabi75 = anbarKeshabi75 + 2
                    }


                    if (arrayAndazeTolha[0] === 300) {
                        anbarKeshabi300 = anbarKeshabi300 + 4
                    }
                    else if (arrayAndazeTolha[0] === 250) {
                        anbarKeshabi250 = anbarKeshabi250 + 4
                    }
                    else if (arrayAndazeTolha[0] === 130) {
                        anbarKeshabi130 = anbarKeshabi130 + 4
                    }
                    else if (arrayAndazeTolha[0] === 100) {
                        anbarKeshabi100 = anbarKeshabi100 + 4
                    }
                    else if (arrayAndazeTolha[0] === 75) {
                        anbarKeshabi75 = anbarKeshabi75 + 4
                    }
                    anbarPlayt130 = anbarPlayt130 + 1
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1
                    } else {
                        resultMsg = false;
                    }


                }

            }
            else if (firstHeight === 100) {
                if (widthMSD1[0] === 1 || widthMSD1[0] === 2 || widthMSD1[0] === 3) {
                    if (faseleDRCH[0] === 300) {
                        anbarKeshabi300 = anbarKeshabi300 + 2
                    }
                    else if (faseleDRCH[0] === 250) {
                        anbarKeshabi250 = anbarKeshabi250 + 2
                    }
                    else if (faseleDRCH[0] === 130) {
                        anbarKeshabi130 = anbarKeshabi130 + 2
                    }
                    else if (faseleDRCH[0] === 100) {
                        anbarKeshabi100 = anbarKeshabi100 + 2
                    }
                    else if (faseleDRCH[0] === 75) {
                        anbarKeshabi75 = anbarKeshabi75 + 2
                    }

                    if (arrayAndazeTolha[0] === 300) {
                        anbarKeshabi300 = anbarKeshabi300 + 4
                    }
                    else if (arrayAndazeTolha[0] === 250) {
                        anbarKeshabi250 = anbarKeshabi250 + 4
                    }
                    else if (arrayAndazeTolha[0] === 130) {
                        anbarKeshabi130 = anbarKeshabi130 + 4
                    }
                    else if (arrayAndazeTolha[0] === 100) {
                        anbarKeshabi100 = anbarKeshabi100 + 4
                    }
                    else if (arrayAndazeTolha[0] === 75) {
                        anbarKeshabi75 = anbarKeshabi75 + 4
                    }
                    anbarPlayt100 = anbarPlayt100 + 1
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1
                    } else {
                        resultMsg = false;
                    }


                }

            }
            else if (firstHeight === 75) {

                if (widthMSD1[0] === 1 || widthMSD1[0] === 2 || widthMSD1[0] === 3) {
                    if (faseleDRCH[0] === 300) {
                        anbarKeshabi300 = anbarKeshabi300 + 2
                    }
                    else if (faseleDRCH[0] === 250) {
                        anbarKeshabi250 = anbarKeshabi250 + 2
                    }
                    else if (faseleDRCH[0] === 130) {
                        anbarKeshabi130 = anbarKeshabi130 + 2
                    }
                    else if (faseleDRCH[0] === 100) {
                        anbarKeshabi100 = anbarKeshabi100 + 2
                    }
                    else if (faseleDRCH[0] === 75) {
                        anbarKeshabi75 = anbarKeshabi75 + 2
                    }

                    if (arrayAndazeTolha[0] === 300) {
                        anbarKeshabi300 = anbarKeshabi300 + 4
                    }
                    else if (arrayAndazeTolha[0] === 250) {
                        anbarKeshabi250 = anbarKeshabi250 + 4
                    }
                    else if (arrayAndazeTolha[0] === 130) {
                        anbarKeshabi130 = anbarKeshabi130 + 4
                    }
                    else if (arrayAndazeTolha[0] === 100) {
                        anbarKeshabi100 = anbarKeshabi100 + 4
                    }
                    else if (arrayAndazeTolha[0] === 75) {
                        anbarKeshabi75 = anbarKeshabi75 + 4
                    }
                    anbarPlayt75 = anbarPlayt75 + 1
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1
                    } else {
                        resultMsg = false;
                    }


                }

            }
            if (halatSD1[i] === 1) {

                for (j = 0; j < faseleDRCH.length; j++) {


                    if (j === 0) {
                        if (faseleDRCH[j] === 300) {
                            if (anbarKeshabi300 >= 2) {
                                anbarKeshabi300 = anbarKeshabi300 - 2;
                            }
                            else {
                                resultMsg = false;
                            }
                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 9) {
                                    anbarPlayt300 = anbarPlayt300 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 9) {
                                    anbarPlayt250 = anbarPlayt250 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 9) {
                                    anbarPlayt130 = anbarPlayt130 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 9) {
                                    anbarPlayt100 = anbarPlayt100 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 75) {
                                if (anbarPlayt75 >= 9) {
                                    anbarPlayt75 = anbarPlayt75 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }

                        }
                        else if (faseleDRCH[j] === 250) {
                            if (anbarKeshabi250 >= 2) {
                                anbarKeshabi250 = anbarKeshabi250 - 2;


                            } else {
                                resultMsg = false;
                            }
                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 7) {
                                    anbarPlayt300 = anbarPlayt300 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 7) {
                                    anbarPlayt250 = anbarPlayt250 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 7) {
                                    anbarPlayt130 = anbarPlayt130 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 7) {
                                    anbarPlayt100 = anbarPlayt100 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 75) {
                                if (anbarPlayt75 >= 7) {
                                    anbarPlayt75 = anbarPlayt75 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }

                        }
                        else if (faseleDRCH[j] === 130) {
                            if (anbarKeshabi130 >= 2) {
                                anbarKeshabi130 = anbarKeshabi130 - 2;
                            } else {
                                resultMsg = false;
                            }
                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 4) {
                                    anbarPlayt300 = anbarPlayt300 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 4) {
                                    anbarPlayt250 = anbarPlayt250 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 4) {
                                    anbarPlayt130 = anbarPlayt130 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 4) {
                                    anbarPlayt100 = anbarPlayt100 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 45) {
                                if (anbarPlayt75 >= 4) {
                                    anbarPlayt75 = anbarPlayt75 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }


                        }
                        else if (faseleDRCH[j] === 100) {
                            if (anbarKeshabi100 >= 2) {
                                anbarKeshabi100 = anbarKeshabi100 - 2;
                            } else {
                                resultMsg = false;
                            }
                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 3) {
                                    anbarPlayt300 = anbarPlayt300 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 3) {
                                    anbarPlayt250 = anbarPlayt250 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 3) {
                                    anbarPlayt130 = anbarPlayt130 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 3) {
                                    anbarPlayt100 = anbarPlayt100 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 75) {
                                if (anbarPlayt75 >= 3) {
                                    anbarPlayt75 = anbarPlayt75 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }

                        }
                        else if (faseleDRCH[j] === 75) {

                            if (anbarKeshabi75 >= 2) {
                                anbarKeshabi75 = anbarKeshabi75 - 2;


                            } else {
                                resultMsg = false;
                            }
                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 2) {
                                    anbarPlayt300 = anbarPlayt300 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 2) {
                                    anbarPlayt250 = anbarPlayt250 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 2) {
                                    anbarPlayt130 = anbarPlayt130 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 2) {
                                    anbarPlayt100 = anbarPlayt100 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 75) {
                                if (anbarPlayt75 >= 2) {
                                    anbarPlayt75 = anbarPlayt75 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                        }
                    }
                    else {

                        if (faseleDRCH[j] === 300) {
                            if (anbarKeshabi300 >= 4) {
                                anbarKeshabi300 = anbarKeshabi300 - 4;
                            }
                            else {
                                resultMsg = false;
                            }
                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 9) {
                                    anbarPlayt300 = anbarPlayt300 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 9) {
                                    anbarPlayt250 = anbarPlayt250 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 9) {
                                    anbarPlayt130 = anbarPlayt130 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 9) {
                                    anbarPlayt100 = anbarPlayt100 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 75) {
                                if (anbarPlayt75 >= 9) {
                                    anbarPlayt75 = anbarPlayt75 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }

                        }
                        else if (faseleDRCH[j] === 250) {
                            if (anbarKeshabi250 >= 4) {
                                anbarKeshabi250 = anbarKeshabi250 - 4;


                            } else {
                                resultMsg = false;
                            }
                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 7) {
                                    anbarPlayt300 = anbarPlayt300 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 7) {
                                    anbarPlayt250 = anbarPlayt250 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 7) {
                                    anbarPlayt130 = anbarPlayt130 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 7) {
                                    anbarPlayt100 = anbarPlayt100 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 75) {
                                if (anbarPlayt75 >= 7) {
                                    anbarPlayt75 = anbarPlayt75 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }

                        }
                        else if (faseleDRCH[j] === 130) {
                            if (anbarKeshabi130 >= 4) {
                                anbarKeshabi130 = anbarKeshabi130 - 4;
                            } else {
                                resultMsg = false;
                            }
                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 4) {
                                    anbarPlayt300 = anbarPlayt300 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 4) {
                                    anbarPlayt250 = anbarPlayt250 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 4) {
                                    anbarPlayt130 = anbarPlayt130 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 4) {
                                    anbarPlayt100 = anbarPlayt100 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 45) {
                                if (anbarPlayt75 >= 4) {
                                    anbarPlayt75 = anbarPlayt75 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }


                        }
                        else if (faseleDRCH[j] === 100) {
                            if (anbarKeshabi100 >= 4) {
                                anbarKeshabi100 = anbarKeshabi100 - 4;
                            } else {
                                resultMsg = false;
                            }
                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 3) {
                                    anbarPlayt300 = anbarPlayt300 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 3) {
                                    anbarPlayt250 = anbarPlayt250 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 3) {
                                    anbarPlayt130 = anbarPlayt130 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 3) {
                                    anbarPlayt100 = anbarPlayt100 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 75) {
                                if (anbarPlayt75 >= 3) {
                                    anbarPlayt75 = anbarPlayt75 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }

                        }
                        else if (faseleDRCH[j] === 75) {
                            if (anbarKeshabi75 >= 4) {
                                anbarKeshabi75 = anbarKeshabi75 - 4;


                            } else {
                                resultMsg = false;
                            }
                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 2) {
                                    anbarPlayt300 = anbarPlayt300 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 2) {
                                    anbarPlayt250 = anbarPlayt250 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 2) {
                                    anbarPlayt130 = anbarPlayt130 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 2) {
                                    anbarPlayt100 = anbarPlayt100 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 75) {
                                if (anbarPlayt75 >= 2) {
                                    anbarPlayt75 = anbarPlayt75 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                        }
                    }


                }


                for (g = 1; g < makanSath[i]; g++) {

                    if (g !== 1) {
                        var n = chekeHeght.includes(heightMSD1[i] + "" + g);
                        if (n === false) {

                            if (arrayAndazeTolha[g] === 300) {
                                if (anbarKeshabi300 >= 4) {
                                    anbarKeshabi300 = anbarKeshabi300 - 4;

                                } else {
                                    resultMsg = false;
                                }

                                if (faseleDRCH[0] === 300) {

                                    if (anbarPlayt300 >= 9) {
                                        anbarPlayt300 = anbarPlayt300 - 9;
                                    } else {
                                        resultMsg = false;
                                    }
                                }
                                else if (faseleDRCH[0] === 250) {
                                    if (anbarPlayt300 >= 7) {
                                        anbarPlayt300 = anbarPlayt300 - 7;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 130) {
                                    if (anbarPlayt300 >= 4) {
                                        anbarPlayt300 = anbarPlayt300 - 4;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 100) {
                                    if (anbarPlayt300 >= 3) {
                                        anbarPlayt300 = anbarPlayt300 - 3;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 75) {
                                    if (anbarPlayt300 >= 2) {
                                        anbarPlayt300 = anbarPlayt300 - 2;
                                    } else {
                                        resultMsg = false;
                                    }

                                }


                            }

                            else if (arrayAndazeTolha[g] === 250) {
                                if (anbarKeshabi250 >= 4) {
                                    anbarKeshabi250 = anbarKeshabi250 - 4;

                                } else {
                                    resultMsg = false;
                                }

                                if (faseleDRCH[0] === 300) {

                                    if (anbarPlayt250 >= 9) {
                                        anbarPlayt250 = anbarPlayt250 - 9;
                                    } else {
                                        resultMsg = false;
                                    }
                                }
                                else if (faseleDRCH[0] === 250) {
                                    if (anbarPlayt250 >= 7) {
                                        anbarPlayt250 = anbarPlayt250 - 7;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 130) {
                                    if (anbarPlayt250 >= 4) {
                                        anbarPlayt250 = anbarPlayt250 - 4;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 100) {
                                    if (anbarPlayt250 >= 3) {
                                        anbarPlayt250 = anbarPlayt250 - 3;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 75) {
                                    if (anbarPlayt250 >= 2) {
                                        anbarPlayt250 = anbarPlayt250 - 2;
                                    } else {
                                        resultMsg = false;
                                    }

                                }


                            }

                            else if (arrayAndazeTolha[g] === 130) {
                                if (anbarKeshabi130 >= 4) {
                                    anbarKeshabi130 = anbarKeshabi130 - 4;
                                } else {
                                    resultMsg = false;
                                }
                                if (faseleDRCH[0] === 300) {

                                    if (anbarPlayt130 >= 9) {
                                        anbarPlayt130 = anbarPlayt130 - 9;
                                    } else {
                                        resultMsg = false;
                                    }
                                }
                                else if (faseleDRCH[0] === 250) {
                                    if (anbarPlayt130 >= 7) {
                                        anbarPlayt130 = anbarPlayt130 - 7;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 130) {
                                    if (anbarPlayt130 >= 4) {
                                        anbarPlayt130 = anbarPlayt130 - 4;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 100) {
                                    if (anbarPlayt130 >= 3) {
                                        anbarPlayt130 = anbarPlayt130 - 3;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 75) {
                                    if (anbarPlayt130 >= 2) {
                                        anbarPlayt130 = anbarPlayt130 - 2;
                                    } else {
                                        resultMsg = false;
                                    }

                                }


                            }

                            else if (arrayAndazeTolha[g] === 100) {
                                if (anbarKeshabi100 >= 4) {
                                    anbarKeshabi100 = anbarKeshabi100 - 4;

                                } else {
                                    resultMsg = false;
                                }

                                if (faseleDRCH[0] === 300) {

                                    if (anbarPlayt100 >= 9) {
                                        anbarPlayt100 = anbarPlayt100 - 9;
                                    } else {
                                        resultMsg = false;
                                    }
                                }
                                else if (faseleDRCH[0] === 250) {
                                    if (anbarPlayt100 >= 7) {
                                        anbarPlayt100 = anbarPlayt100 - 7;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 130) {
                                    if (anbarPlayt100 >= 4) {
                                        anbarPlayt100 = anbarPlayt100 - 4;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 100) {
                                    if (anbarPlayt100 >= 3) {
                                        anbarPlayt100 = anbarPlayt100 - 3;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 75) {
                                    if (anbarPlayt100 >= 2) {
                                        anbarPlayt100 = anbarPlayt100 - 2;
                                    } else {
                                        resultMsg = false;
                                    }

                                }

                            }

                            else if (arrayAndazeTolha[g] === 75) {
                                if (anbarKeshabi75 >= 4) {
                                    anbarKeshabi75 = anbarKeshabi75 - 4;

                                } else {
                                    resultMsg = false;
                                }
                                if (faseleDRCH[0] === 300) {

                                    if (anbarPlayt75 >= 9) {
                                        anbarPlayt75 = anbarPlayt75 - 9;
                                    } else {
                                        resultMsg = false;
                                    }
                                }
                                else if (faseleDRCH[0] === 250) {
                                    if (anbarPlayt75 >= 7) {
                                        anbarPlayt75 = anbarPlayt75 - 7;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 130) {
                                    if (anbarPlayt75 >= 4) {
                                        anbarPlayt75 = anbarPlayt75 - 4;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 100) {
                                    if (anbarPlayt75 >= 3) {
                                        anbarPlayt75 = anbarPlayt75 - 3;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 75) {
                                    if (anbarPlayt75 >= 2) {
                                        anbarPlayt75 = anbarPlayt75 - 2;
                                    } else {
                                        resultMsg = false;
                                    }

                                }


                            }

                        }
                    }
                    chekeHeght.push(heightMSD1[i] + "" + g)


                }

                if (arrayAndazeTolha[makanSath[i]] === 300) {


                    if (anbarKeshabi300 >= 4) {
                        anbarKeshabi300 = anbarKeshabi300 - 4;

                    } else {
                        resultMsg = false;
                    }

                }
                else if (arrayAndazeTolha[makanSath[i]] === 250) {
                    if (anbarKeshabi250 >= 4) {
                        anbarKeshabi250 = anbarKeshabi250 - 4;


                    } else {
                        resultMsg = false;
                    }

                }
                else if (arrayAndazeTolha[makanSath[i]] === 130) {
                    if (anbarKeshabi130 >= 4) {
                        anbarKeshabi130 = anbarKeshabi130 - 4;

                    } else {
                        resultMsg = false;
                    }

                }
                else if (arrayAndazeTolha[makanSath[i]] === 100) {
                    if (anbarKeshabi100 >= 4) {
                        anbarKeshabi100 = anbarKeshabi100 - 4;


                    } else {
                        resultMsg = false;
                    }

                }
                else if (arrayAndazeTolha[makanSath[i]] === 75) {
                    if (anbarKeshabi75 >= 4) {
                        anbarKeshabi75 = anbarKeshabi75 - 4;


                    } else {
                        resultMsg = false;
                    }

                }


            }
            if (halatSD1[i] === 2) {

                for (j = 0; j < faseleDRCH.length; j++) {
                    if (j === 0) {
                        if (faseleDRCH[j] === 300) {
                            if (anbarKeshabi300 >= 2) {
                                anbarKeshabi300 = anbarKeshabi300 - 2;
                            }
                            else {
                                resultMsg = false;
                            }


                            if (arrayAndazeTolha[makanSath[i] + 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] + 1] === 300) {

                                    if (anbarPlayt300 >= 9) {
                                        anbarPlayt300 = anbarPlayt300 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 250) {
                                    if (anbarPlayt250 >= 9) {
                                        anbarPlayt250 = anbarPlayt250 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 130) {
                                    if (anbarPlayt130 >= 9) {
                                        anbarPlayt130 = anbarPlayt130 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 100) {
                                    if (anbarPlayt100 >= 9) {
                                        anbarPlayt100 = anbarPlayt100 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 75) {
                                    if (anbarPlayt75 >= 9) {
                                        anbarPlayt75 = anbarPlayt75 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                    if (anbarPlayt300 >= 9) {
                                        anbarPlayt300 = anbarPlayt300 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                    if (anbarPlayt250 >= 9) {
                                        anbarPlayt250 = anbarPlayt250 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                    if (anbarPlayt130 >= 9) {
                                        anbarPlayt130 = anbarPlayt130 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                    if (anbarPlayt100 >= 9) {
                                        anbarPlayt100 = anbarPlayt100 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                                    if (anbarPlayt75 >= 9) {
                                        anbarPlayt75 = anbarPlayt75 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                            }

                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 9) {
                                    anbarPlayt300 = anbarPlayt300 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 9) {
                                    anbarPlayt250 = anbarPlayt250 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 9) {
                                    anbarPlayt130 = anbarPlayt130 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 9) {
                                    anbarPlayt100 = anbarPlayt100 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 75) {
                                if (anbarPlayt75 >= 9) {
                                    anbarPlayt75 = anbarPlayt75 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }

                        }
                        else if (faseleDRCH[j] === 250) {
                            if (anbarKeshabi250 >= 2) {
                                anbarKeshabi250 = anbarKeshabi250 - 2;


                            } else {
                                resultMsg = false;
                            }


                            if (arrayAndazeTolha[makanSath[i] + 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] + 1] === 300) {

                                    if (anbarPlayt300 >= 7) {
                                        anbarPlayt300 = anbarPlayt300 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 250) {
                                    if (anbarPlayt250 >= 7) {
                                        anbarPlayt250 = anbarPlayt250 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 130) {
                                    if (anbarPlayt130 >= 7) {
                                        anbarPlayt130 = anbarPlayt130 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 100) {
                                    if (anbarPlayt100 >= 7) {
                                        anbarPlayt100 = anbarPlayt100 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 75) {
                                    if (anbarPlayt75 >= 7) {
                                        anbarPlayt75 = anbarPlayt75 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                    if (anbarPlayt300 >= 7) {
                                        anbarPlayt300 = anbarPlayt300 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                    if (anbarPlayt250 >= 7) {
                                        anbarPlayt250 = anbarPlayt250 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                    if (anbarPlayt130 >= 7) {
                                        anbarPlayt130 = anbarPlayt130 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                    if (anbarPlayt100 >= 7) {
                                        anbarPlayt100 = anbarPlayt100 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                                    if (anbarPlayt75 >= 7) {
                                        anbarPlayt75 = anbarPlayt75 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                            }


                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 7) {
                                    anbarPlayt300 = anbarPlayt300 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 7) {
                                    anbarPlayt250 = anbarPlayt250 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 7) {
                                    anbarPlayt130 = anbarPlayt130 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 7) {
                                    anbarPlayt100 = anbarPlayt100 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 75) {
                                if (anbarPlayt75 >= 7) {
                                    anbarPlayt75 = anbarPlayt75 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }

                        }
                        else if (faseleDRCH[j] === 130) {
                            if (anbarKeshabi130 >= 2) {
                                anbarKeshabi130 = anbarKeshabi130 - 2;
                            } else {
                                resultMsg = false;
                            }

                            if (arrayAndazeTolha[makanSath[i] + 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] + 1] === 300) {

                                    if (anbarPlayt300 >= 4) {
                                        anbarPlayt300 = anbarPlayt300 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 250) {
                                    if (anbarPlayt250 >= 4) {
                                        anbarPlayt250 = anbarPlayt250 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 130) {
                                    if (anbarPlayt130 >= 4) {
                                        anbarPlayt130 = anbarPlayt130 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 100) {
                                    if (anbarPlayt100 >= 4) {
                                        anbarPlayt100 = anbarPlayt100 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 45) {
                                    if (anbarPlayt75 >= 4) {
                                        anbarPlayt75 = anbarPlayt75 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                    if (anbarPlayt300 >= 4) {
                                        anbarPlayt300 = anbarPlayt300 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                    if (anbarPlayt250 >= 4) {
                                        anbarPlayt250 = anbarPlayt250 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                    if (anbarPlayt130 >= 4) {
                                        anbarPlayt130 = anbarPlayt130 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                    if (anbarPlayt100 >= 4) {
                                        anbarPlayt100 = anbarPlayt100 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 45) {
                                    if (anbarPlayt75 >= 4) {
                                        anbarPlayt75 = anbarPlayt75 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }

                            }


                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 4) {
                                    anbarPlayt300 = anbarPlayt300 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 4) {
                                    anbarPlayt250 = anbarPlayt250 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 4) {
                                    anbarPlayt130 = anbarPlayt130 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 4) {
                                    anbarPlayt100 = anbarPlayt100 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 45) {
                                if (anbarPlayt75 >= 4) {
                                    anbarPlayt75 = anbarPlayt75 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }


                        }
                        else if (faseleDRCH[j] === 100) {
                            //alert("jghj")
                            if (anbarKeshabi100 >= 2) {
                                anbarKeshabi100 = anbarKeshabi100 - 2;
                            } else {
                                resultMsg = false;
                            }

                            if (arrayAndazeTolha[makanSath[i] + 1] !== undefined) {
                                if (arrayAndazeTolha[makanSath[i] + 1] === 300) {

                                    if (anbarPlayt300 >= 3) {
                                        anbarPlayt300 = anbarPlayt300 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 250) {
                                    if (anbarPlayt250 >= 3) {
                                        anbarPlayt250 = anbarPlayt250 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 130) {
                                    if (anbarPlayt130 >= 3) {
                                        anbarPlayt130 = anbarPlayt130 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 100) {
                                    if (anbarPlayt100 >= 3) {
                                        anbarPlayt100 = anbarPlayt100 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 75) {
                                    if (anbarPlayt75 >= 3) {
                                        anbarPlayt75 = anbarPlayt75 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {
                                if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                    if (anbarPlayt300 >= 3) {
                                        anbarPlayt300 = anbarPlayt300 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                    if (anbarPlayt250 >= 3) {
                                        anbarPlayt250 = anbarPlayt250 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                    if (anbarPlayt130 >= 3) {
                                        anbarPlayt130 = anbarPlayt130 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                    if (anbarPlayt100 >= 3) {
                                        anbarPlayt100 = anbarPlayt100 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                                    if (anbarPlayt75 >= 3) {
                                        anbarPlayt75 = anbarPlayt75 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                            }


                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 3) {
                                    anbarPlayt300 = anbarPlayt300 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 3) {
                                    anbarPlayt250 = anbarPlayt250 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 3) {
                                    anbarPlayt130 = anbarPlayt130 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 3) {
                                    anbarPlayt100 = anbarPlayt100 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 75) {
                                if (anbarPlayt75 >= 3) {
                                    anbarPlayt75 = anbarPlayt75 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }

                        }
                        else if (faseleDRCH[j] === 75) {
                            if (anbarKeshabi75 >= 2) {
                                anbarKeshabi75 = anbarKeshabi75 - 2;


                            } else {
                                resultMsg = false;
                            }

                            if (arrayAndazeTolha[makanSath[i] + 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] + 1] === 300) {

                                    if (anbarPlayt300 >= 2) {
                                        anbarPlayt300 = anbarPlayt300 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 250) {
                                    if (anbarPlayt250 >= 2) {
                                        anbarPlayt250 = anbarPlayt250 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 130) {
                                    if (anbarPlayt130 >= 2) {
                                        anbarPlayt130 = anbarPlayt130 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 100) {
                                    if (anbarPlayt100 >= 2) {
                                        anbarPlayt100 = anbarPlayt100 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 75) {
                                    if (anbarPlayt75 >= 2) {
                                        anbarPlayt75 = anbarPlayt75 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                    if (anbarPlayt300 >= 2) {
                                        anbarPlayt300 = anbarPlayt300 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                    if (anbarPlayt250 >= 2) {
                                        anbarPlayt250 = anbarPlayt250 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                    if (anbarPlayt130 >= 2) {
                                        anbarPlayt130 = anbarPlayt130 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                    if (anbarPlayt100 >= 2) {
                                        anbarPlayt100 = anbarPlayt100 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                                    if (anbarPlayt75 >= 2) {
                                        anbarPlayt75 = anbarPlayt75 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                            }


                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 2) {
                                    anbarPlayt300 = anbarPlayt300 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 2) {
                                    anbarPlayt250 = anbarPlayt250 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 2) {
                                    anbarPlayt130 = anbarPlayt130 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 2) {
                                    anbarPlayt100 = anbarPlayt100 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 75) {
                                if (anbarPlayt75 >= 2) {
                                    anbarPlayt75 = anbarPlayt75 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                        }
                    }
                    else {

                        if (faseleDRCH[j] === 300) {
                            if (anbarKeshabi300 >= 4) {
                                anbarKeshabi300 = anbarKeshabi300 - 4;
                            }
                            else {
                                resultMsg = false;
                            }
                            if (arrayAndazeTolha[makanSath[i] + 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] + 1] === 300) {

                                    if (anbarPlayt300 >= 9) {
                                        anbarPlayt300 = anbarPlayt300 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 250) {
                                    if (anbarPlayt250 >= 9) {
                                        anbarPlayt250 = anbarPlayt250 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 130) {
                                    if (anbarPlayt130 >= 9) {
                                        anbarPlayt130 = anbarPlayt130 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 100) {
                                    if (anbarPlayt100 >= 9) {
                                        anbarPlayt100 = anbarPlayt100 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 75) {
                                    if (anbarPlayt75 >= 9) {
                                        anbarPlayt75 = anbarPlayt75 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                    if (anbarPlayt300 >= 9) {
                                        anbarPlayt300 = anbarPlayt300 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                    if (anbarPlayt250 >= 9) {
                                        anbarPlayt250 = anbarPlayt250 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                    if (anbarPlayt130 >= 9) {
                                        anbarPlayt130 = anbarPlayt130 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                    if (anbarPlayt100 >= 9) {
                                        anbarPlayt100 = anbarPlayt100 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                                    if (anbarPlayt75 >= 9) {
                                        anbarPlayt75 = anbarPlayt75 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                            }


                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 9) {
                                    anbarPlayt300 = anbarPlayt300 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 9) {
                                    anbarPlayt250 = anbarPlayt250 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 9) {
                                    anbarPlayt130 = anbarPlayt130 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 9) {
                                    anbarPlayt100 = anbarPlayt100 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 75) {
                                if (anbarPlayt75 >= 9) {
                                    anbarPlayt75 = anbarPlayt75 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }

                        }
                        else if (faseleDRCH[j] === 250) {
                            if (anbarKeshabi250 >= 4) {
                                anbarKeshabi250 = anbarKeshabi250 - 4;


                            } else {
                                resultMsg = false;
                            }

                            if (arrayAndazeTolha[makanSath[i] + 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] + 1] === 300) {

                                    if (anbarPlayt300 >= 7) {
                                        anbarPlayt300 = anbarPlayt300 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 250) {
                                    if (anbarPlayt250 >= 7) {
                                        anbarPlayt250 = anbarPlayt250 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 130) {
                                    if (anbarPlayt130 >= 7) {
                                        anbarPlayt130 = anbarPlayt130 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 100) {
                                    if (anbarPlayt100 >= 7) {
                                        anbarPlayt100 = anbarPlayt100 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 75) {
                                    if (anbarPlayt75 >= 7) {
                                        anbarPlayt75 = anbarPlayt75 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                    if (anbarPlayt300 >= 7) {
                                        anbarPlayt300 = anbarPlayt300 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                    if (anbarPlayt250 >= 7) {
                                        anbarPlayt250 = anbarPlayt250 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                    if (anbarPlayt130 >= 7) {
                                        anbarPlayt130 = anbarPlayt130 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                    if (anbarPlayt100 >= 7) {
                                        anbarPlayt100 = anbarPlayt100 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                                    if (anbarPlayt75 >= 7) {
                                        anbarPlayt75 = anbarPlayt75 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                            }
                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 7) {
                                    anbarPlayt300 = anbarPlayt300 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 7) {
                                    anbarPlayt250 = anbarPlayt250 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 7) {
                                    anbarPlayt130 = anbarPlayt130 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 7) {
                                    anbarPlayt100 = anbarPlayt100 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 75) {
                                if (anbarPlayt75 >= 7) {
                                    anbarPlayt75 = anbarPlayt75 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }

                        }
                        else if (faseleDRCH[j] === 130) {
                            if (anbarKeshabi130 >= 4) {
                                anbarKeshabi130 = anbarKeshabi130 - 4;
                            } else {
                                resultMsg = false;
                            }
                            if (arrayAndazeTolha[makanSath[i] + 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] + 1] === 300) {

                                    if (anbarPlayt300 >= 4) {
                                        anbarPlayt300 = anbarPlayt300 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 250) {
                                    if (anbarPlayt250 >= 4) {
                                        anbarPlayt250 = anbarPlayt250 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 130) {
                                    if (anbarPlayt130 >= 4) {
                                        anbarPlayt130 = anbarPlayt130 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 100) {
                                    if (anbarPlayt100 >= 4) {
                                        anbarPlayt100 = anbarPlayt100 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 45) {
                                    if (anbarPlayt75 >= 4) {
                                        anbarPlayt75 = anbarPlayt75 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                    if (anbarPlayt300 >= 4) {
                                        anbarPlayt300 = anbarPlayt300 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                    if (anbarPlayt250 >= 4) {
                                        anbarPlayt250 = anbarPlayt250 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                    if (anbarPlayt130 >= 4) {
                                        anbarPlayt130 = anbarPlayt130 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                    if (anbarPlayt100 >= 4) {
                                        anbarPlayt100 = anbarPlayt100 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 45) {
                                    if (anbarPlayt75 >= 4) {
                                        anbarPlayt75 = anbarPlayt75 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }

                            }

                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 4) {
                                    anbarPlayt300 = anbarPlayt300 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 4) {
                                    anbarPlayt250 = anbarPlayt250 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 4) {
                                    anbarPlayt130 = anbarPlayt130 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 4) {
                                    anbarPlayt100 = anbarPlayt100 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 45) {
                                if (anbarPlayt75 >= 4) {
                                    anbarPlayt75 = anbarPlayt75 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }


                        }
                        else if (faseleDRCH[j] === 100) {
                            if (anbarKeshabi100 >= 4) {
                                anbarKeshabi100 = anbarKeshabi100 - 4;
                            } else {
                                resultMsg = false;
                            }


                            if (arrayAndazeTolha[makanSath[i] + 1] !== undefined) {
                                if (arrayAndazeTolha[makanSath[i] + 1] === 300) {

                                    if (anbarPlayt300 >= 3) {
                                        anbarPlayt300 = anbarPlayt300 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 250) {
                                    if (anbarPlayt250 >= 3) {
                                        anbarPlayt250 = anbarPlayt250 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 130) {
                                    if (anbarPlayt130 >= 3) {
                                        anbarPlayt130 = anbarPlayt130 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 100) {
                                    if (anbarPlayt100 >= 3) {
                                        anbarPlayt100 = anbarPlayt100 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 75) {
                                    if (anbarPlayt75 >= 3) {
                                        anbarPlayt75 = anbarPlayt75 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {
                                if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                    if (anbarPlayt300 >= 3) {
                                        anbarPlayt300 = anbarPlayt300 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                    if (anbarPlayt250 >= 3) {
                                        anbarPlayt250 = anbarPlayt250 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                    if (anbarPlayt130 >= 3) {
                                        anbarPlayt130 = anbarPlayt130 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                    if (anbarPlayt100 >= 3) {
                                        anbarPlayt100 = anbarPlayt100 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                                    if (anbarPlayt75 >= 3) {
                                        anbarPlayt75 = anbarPlayt75 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                            }

                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 3) {
                                    anbarPlayt300 = anbarPlayt300 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 3) {
                                    anbarPlayt250 = anbarPlayt250 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 3) {
                                    anbarPlayt130 = anbarPlayt130 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 3) {
                                    anbarPlayt100 = anbarPlayt100 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 75) {
                                if (anbarPlayt75 >= 3) {
                                    anbarPlayt75 = anbarPlayt75 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }

                        }
                        else if (faseleDRCH[j] === 75) {
                            if (anbarKeshabi75 >= 4) {
                                anbarKeshabi75 = anbarKeshabi75 - 4;


                            } else {
                                resultMsg = false;
                            }

                            if (arrayAndazeTolha[makanSath[i] + 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] + 1] === 300) {

                                    if (anbarPlayt300 >= 2) {
                                        anbarPlayt300 = anbarPlayt300 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 250) {
                                    if (anbarPlayt250 >= 2) {
                                        anbarPlayt250 = anbarPlayt250 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 130) {
                                    if (anbarPlayt130 >= 2) {
                                        anbarPlayt130 = anbarPlayt130 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 100) {
                                    if (anbarPlayt100 >= 2) {
                                        anbarPlayt100 = anbarPlayt100 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 75) {
                                    if (anbarPlayt75 >= 2) {
                                        anbarPlayt75 = anbarPlayt75 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                    if (anbarPlayt300 >= 2) {
                                        anbarPlayt300 = anbarPlayt300 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                    if (anbarPlayt250 >= 2) {
                                        anbarPlayt250 = anbarPlayt250 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                    if (anbarPlayt130 >= 2) {
                                        anbarPlayt130 = anbarPlayt130 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                    if (anbarPlayt100 >= 2) {
                                        anbarPlayt100 = anbarPlayt100 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                                    if (anbarPlayt75 >= 2) {
                                        anbarPlayt75 = anbarPlayt75 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                            }

                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 2) {
                                    anbarPlayt300 = anbarPlayt300 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 2) {
                                    anbarPlayt250 = anbarPlayt250 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 2) {
                                    anbarPlayt130 = anbarPlayt130 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 2) {
                                    anbarPlayt100 = anbarPlayt100 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 75) {
                                if (anbarPlayt75 >= 2) {
                                    anbarPlayt75 = anbarPlayt75 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                        }
                    }


                }


                var makanSathF = 0;
                if (arrayAndazeTolha[makanSath[i] + 1] === undefined) {
                    makanSathF = makanSath[i - 1];

                }
                else {
                    makanSathF = makanSath[i];


                }
                for (g = 1; g < makanSathF; g++) {

                    if (g !== 1) {
                        var n = chekeHeght.includes(heightMSD1[i] + "" + g);
                        if (n === false) {

                            if (arrayAndazeTolha[g] === 300) {
                                if (anbarKeshabi300 >= 4) {
                                    anbarKeshabi300 = anbarKeshabi300 - 4;

                                } else {
                                    resultMsg = false;
                                }

                                if (faseleDRCH[0] === 300) {

                                    if (anbarPlayt300 >= 9) {
                                        anbarPlayt300 = anbarPlayt300 - 9;
                                    } else {
                                        resultMsg = false;
                                    }
                                }
                                else if (faseleDRCH[0] === 250) {
                                    if (anbarPlayt300 >= 7) {
                                        anbarPlayt300 = anbarPlayt300 - 7;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 130) {
                                    if (anbarPlayt300 >= 4) {
                                        anbarPlayt300 = anbarPlayt300 - 4;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 100) {
                                    if (anbarPlayt300 >= 3) {
                                        anbarPlayt300 = anbarPlayt300 - 3;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 75) {
                                    if (anbarPlayt300 >= 2) {
                                        anbarPlayt300 = anbarPlayt300 - 2;
                                    } else {
                                        resultMsg = false;
                                    }

                                }


                            }

                            else if (arrayAndazeTolha[g] === 250) {
                                if (anbarKeshabi250 >= 4) {
                                    anbarKeshabi250 = anbarKeshabi250 - 4;

                                } else {
                                    resultMsg = false;
                                }

                                if (faseleDRCH[0] === 300) {

                                    if (anbarPlayt250 >= 9) {
                                        anbarPlayt250 = anbarPlayt250 - 9;
                                    } else {
                                        resultMsg = false;
                                    }
                                }
                                else if (faseleDRCH[0] === 250) {
                                    if (anbarPlayt250 >= 7) {
                                        anbarPlayt250 = anbarPlayt250 - 7;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 130) {
                                    if (anbarPlayt250 >= 4) {
                                        anbarPlayt250 = anbarPlayt250 - 4;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 100) {
                                    if (anbarPlayt250 >= 3) {
                                        anbarPlayt250 = anbarPlayt250 - 3;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 75) {
                                    if (anbarPlayt250 >= 2) {
                                        anbarPlayt250 = anbarPlayt250 - 2;
                                    } else {
                                        resultMsg = false;
                                    }

                                }


                            }

                            else if (arrayAndazeTolha[g] === 130) {
                                if (anbarKeshabi130 >= 4) {
                                    anbarKeshabi130 = anbarKeshabi130 - 4;
                                } else {
                                    resultMsg = false;
                                }
                                if (faseleDRCH[0] === 300) {

                                    if (anbarPlayt130 >= 9) {
                                        anbarPlayt130 = anbarPlayt130 - 9;
                                    } else {
                                        resultMsg = false;
                                    }
                                }
                                else if (faseleDRCH[0] === 250) {
                                    if (anbarPlayt130 >= 7) {
                                        anbarPlayt130 = anbarPlayt130 - 7;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 130) {
                                    if (anbarPlayt130 >= 4) {
                                        anbarPlayt130 = anbarPlayt130 - 4;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 100) {
                                    if (anbarPlayt130 >= 3) {
                                        anbarPlayt130 = anbarPlayt130 - 3;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 75) {
                                    if (anbarPlayt130 >= 2) {
                                        anbarPlayt130 = anbarPlayt130 - 2;
                                    } else {
                                        resultMsg = false;
                                    }

                                }


                            }

                            else if (arrayAndazeTolha[g] === 100) {
                                if (anbarKeshabi100 >= 4) {
                                    anbarKeshabi100 = anbarKeshabi100 - 4;

                                } else {
                                    resultMsg = false;
                                }

                                if (faseleDRCH[0] === 300) {

                                    if (anbarPlayt100 >= 9) {
                                        anbarPlayt100 = anbarPlayt100 - 9;
                                    } else {
                                        resultMsg = false;
                                    }
                                }
                                else if (faseleDRCH[0] === 250) {
                                    if (anbarPlayt100 >= 7) {
                                        anbarPlayt100 = anbarPlayt100 - 7;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 130) {
                                    if (anbarPlayt100 >= 4) {
                                        anbarPlayt100 = anbarPlayt100 - 4;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 100) {
                                    if (anbarPlayt100 >= 3) {
                                        anbarPlayt100 = anbarPlayt100 - 3;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 75) {
                                    if (anbarPlayt100 >= 2) {
                                        anbarPlayt100 = anbarPlayt100 - 2;
                                    } else {
                                        resultMsg = false;
                                    }

                                }

                            }

                            else if (arrayAndazeTolha[g] === 75) {
                                if (anbarKeshabi75 >= 4) {
                                    anbarKeshabi75 = anbarKeshabi75 - 4;

                                } else {
                                    resultMsg = false;
                                }
                                if (faseleDRCH[0] === 300) {

                                    if (anbarPlayt75 >= 9) {
                                        anbarPlayt75 = anbarPlayt75 - 9;
                                    } else {
                                        resultMsg = false;
                                    }
                                }
                                else if (faseleDRCH[0] === 250) {
                                    if (anbarPlayt75 >= 7) {
                                        anbarPlayt75 = anbarPlayt75 - 7;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 130) {
                                    if (anbarPlayt75 >= 4) {
                                        anbarPlayt75 = anbarPlayt75 - 4;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 100) {
                                    if (anbarPlayt75 >= 3) {
                                        anbarPlayt75 = anbarPlayt75 - 3;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 75) {
                                    if (anbarPlayt75 >= 2) {
                                        anbarPlayt75 = anbarPlayt75 - 2;
                                    } else {
                                        resultMsg = false;
                                    }

                                }


                            }

                        }
                    }
                    chekeHeght.push(heightMSD1[i] + "" + g)


                }

                if (arrayAndazeTolha[makanSath[i] + 1] !== undefined) {

                    if (arrayAndazeTolha[makanSath[i] + 1] === 300) {
                        if (anbarKeshabi300 >= 4) {
                            anbarKeshabi300 = anbarKeshabi300 - 4;

                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[makanSath[i] + 1] === 250) {
                        if (anbarKeshabi250 >= 4) {
                            anbarKeshabi250 = anbarKeshabi250 - 4;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[makanSath[i] + 1] === 130) {
                        if (anbarKeshabi130 >= 4) {
                            anbarKeshabi130 = anbarKeshabi130 - 4;

                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[makanSath[i] + 1] === 100) {
                        if (anbarKeshabi100 >= 4) {
                            anbarKeshabi100 = anbarKeshabi100 - 4;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[makanSath[i] + 1] === 75) {
                        if (anbarKeshabi75 >= 4) {
                            anbarKeshabi75 = anbarKeshabi75 - 4;


                        } else {
                            resultMsg = false;
                        }

                    }

                }
                else if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {


                    if (arrayAndazeTolha[makanSath[i] - 1] === 300) {
                        if (anbarKeshabi300 >= 4) {
                            anbarKeshabi300 = anbarKeshabi300 - 4;

                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                        if (anbarKeshabi250 >= 4) {
                            anbarKeshabi250 = anbarKeshabi250 - 4;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                        if (anbarKeshabi130 >= 4) {
                            anbarKeshabi130 = anbarKeshabi130 - 4;

                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                        if (anbarKeshabi100 >= 4) {
                            anbarKeshabi100 = anbarKeshabi100 - 4;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                        if (anbarKeshabi75 >= 4) {
                            anbarKeshabi75 = anbarKeshabi75 - 4;


                        } else {
                            resultMsg = false;
                        }

                    }
                }


                if (arrayAndazeTolha[makanSath[i]] === 300) {
                    if (anbarKeshabi300 >= 4) {
                        anbarKeshabi300 = anbarKeshabi300 - 4;

                    } else {
                        resultMsg = false;
                    }

                }
                else if (arrayAndazeTolha[makanSath[i]] === 250) {
                    if (anbarKeshabi250 >= 4) {
                        anbarKeshabi250 = anbarKeshabi250 - 4;


                    } else {
                        resultMsg = false;
                    }

                }
                else if (arrayAndazeTolha[makanSath[i]] === 130) {
                    if (anbarKeshabi130 >= 4) {
                        anbarKeshabi130 = anbarKeshabi130 - 4;

                    } else {
                        resultMsg = false;
                    }

                }
                else if (arrayAndazeTolha[makanSath[i]] === 100) {
                    if (anbarKeshabi100 >= 4) {
                        anbarKeshabi100 = anbarKeshabi100 - 4;


                    } else {
                        resultMsg = false;
                    }

                }
                else if (arrayAndazeTolha[makanSath[i]] === 75) {
                    if (anbarKeshabi75 >= 4) {
                        anbarKeshabi75 = anbarKeshabi75 - 4;


                    } else {
                        resultMsg = false;
                    }

                }


            }
            if (halatSD1[i] === 3) {

                for (j = 0; j < faseleDRCH.length; j++) {

                    if (j === 0) {

                        if (faseleDRCH[j] === 300) {
                            if (anbarKeshabi300 >= 2) {
                                anbarKeshabi300 = anbarKeshabi300 - 2;
                            }
                            else {
                                resultMsg = false;
                            }


                            if (arrayAndazeTolha[makanSath[i] + 1] !== undefined) {


                                if (arrayAndazeTolha[makanSath[i] + 1] === 300) {

                                    if (anbarPlayt300 >= 9) {
                                        anbarPlayt300 = anbarPlayt300 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 250) {
                                    if (anbarPlayt250 >= 9) {
                                        anbarPlayt250 = anbarPlayt250 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 130) {
                                    if (anbarPlayt130 >= 9) {
                                        anbarPlayt130 = anbarPlayt130 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 100) {
                                    if (anbarPlayt100 >= 9) {
                                        anbarPlayt100 = anbarPlayt100 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 75) {
                                    if (anbarPlayt75 >= 9) {
                                        anbarPlayt75 = anbarPlayt75 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }

                                if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {


                                    if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                        if (anbarPlayt300 >= 9) {
                                            anbarPlayt300 = anbarPlayt300 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                        if (anbarPlayt250 >= 9) {
                                            anbarPlayt250 = anbarPlayt250 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                        if (anbarPlayt130 >= 9) {
                                            anbarPlayt130 = anbarPlayt130 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                        if (anbarPlayt100 >= 9) {
                                            anbarPlayt100 = anbarPlayt100 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                                        if (anbarPlayt75 >= 9) {
                                            anbarPlayt75 = anbarPlayt75 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 2] !== undefined) {

                                    if (arrayAndazeTolha[makanSath[i] + 2] === 300) {

                                        if (anbarPlayt300 >= 9) {
                                            anbarPlayt300 = anbarPlayt300 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 250) {
                                        if (anbarPlayt250 >= 9) {
                                            anbarPlayt250 = anbarPlayt250 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 130) {
                                        if (anbarPlayt130 >= 9) {
                                            anbarPlayt130 = anbarPlayt130 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 100) {
                                        if (anbarPlayt100 >= 9) {
                                            anbarPlayt100 = anbarPlayt100 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 75) {
                                        if (anbarPlayt75 >= 9) {
                                            anbarPlayt75 = anbarPlayt75 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {


                                if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                    if (anbarPlayt300 >= 9) {
                                        anbarPlayt300 = anbarPlayt300 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                    if (anbarPlayt250 >= 9) {
                                        anbarPlayt250 = anbarPlayt250 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                    if (anbarPlayt130 >= 9) {
                                        anbarPlayt130 = anbarPlayt130 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                    if (anbarPlayt100 >= 9) {
                                        anbarPlayt100 = anbarPlayt100 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                                    if (anbarPlayt75 >= 9) {
                                        anbarPlayt75 = anbarPlayt75 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }

                                if (arrayAndazeTolha[makanSath[i] - 2] !== undefined) {


                                    if (arrayAndazeTolha[makanSath[i] - 2] === 300) {

                                        if (anbarPlayt300 >= 9) {
                                            anbarPlayt300 = anbarPlayt300 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 250) {
                                        if (anbarPlayt250 >= 9) {
                                            anbarPlayt250 = anbarPlayt250 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 130) {
                                        if (anbarPlayt130 >= 9) {
                                            anbarPlayt130 = anbarPlayt130 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 100) {
                                        if (anbarPlayt100 >= 9) {
                                            anbarPlayt100 = anbarPlayt100 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 75) {
                                        if (anbarPlayt75 >= 9) {
                                            anbarPlayt75 = anbarPlayt75 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                }
                            }


                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 9) {
                                    anbarPlayt300 = anbarPlayt300 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 9) {
                                    anbarPlayt250 = anbarPlayt250 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 9) {
                                    anbarPlayt130 = anbarPlayt130 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 9) {
                                    anbarPlayt100 = anbarPlayt100 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 75) {
                                if (anbarPlayt75 >= 9) {
                                    anbarPlayt75 = anbarPlayt75 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }

                        }
                        else if (faseleDRCH[j] === 250) {
                            if (anbarKeshabi250 >= 2) {
                                anbarKeshabi250 = anbarKeshabi250 - 2;


                            } else {
                                resultMsg = false;
                            }


                            if (arrayAndazeTolha[makanSath[i] + 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] + 1] === 300) {

                                    if (anbarPlayt300 >= 7) {
                                        anbarPlayt300 = anbarPlayt300 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 250) {
                                    if (anbarPlayt250 >= 7) {
                                        anbarPlayt250 = anbarPlayt250 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 130) {
                                    if (anbarPlayt130 >= 7) {
                                        anbarPlayt130 = anbarPlayt130 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 100) {
                                    if (anbarPlayt100 >= 7) {
                                        anbarPlayt100 = anbarPlayt100 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 75) {
                                    if (anbarPlayt75 >= 7) {
                                        anbarPlayt75 = anbarPlayt75 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }

                                if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {

                                    if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                        if (anbarPlayt300 >= 7) {
                                            anbarPlayt300 = anbarPlayt300 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                        if (anbarPlayt250 >= 7) {
                                            anbarPlayt250 = anbarPlayt250 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                        if (anbarPlayt130 >= 7) {
                                            anbarPlayt130 = anbarPlayt130 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                        if (anbarPlayt100 >= 7) {
                                            anbarPlayt100 = anbarPlayt100 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                                        if (anbarPlayt75 >= 7) {
                                            anbarPlayt75 = anbarPlayt75 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 2] !== undefined) {

                                    if (arrayAndazeTolha[makanSath[i] + 2] === 300) {

                                        if (anbarPlayt300 >= 7) {
                                            anbarPlayt300 = anbarPlayt300 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 250) {
                                        if (anbarPlayt250 >= 7) {
                                            anbarPlayt250 = anbarPlayt250 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 130) {
                                        if (anbarPlayt130 >= 7) {
                                            anbarPlayt130 = anbarPlayt130 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 100) {
                                        if (anbarPlayt100 >= 7) {
                                            anbarPlayt100 = anbarPlayt100 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 75) {
                                        if (anbarPlayt75 >= 7) {
                                            anbarPlayt75 = anbarPlayt75 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                    if (anbarPlayt300 >= 7) {
                                        anbarPlayt300 = anbarPlayt300 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                    if (anbarPlayt250 >= 7) {
                                        anbarPlayt250 = anbarPlayt250 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                    if (anbarPlayt130 >= 7) {
                                        anbarPlayt130 = anbarPlayt130 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                    if (anbarPlayt100 >= 7) {
                                        anbarPlayt100 = anbarPlayt100 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                                    if (anbarPlayt75 >= 7) {
                                        anbarPlayt75 = anbarPlayt75 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                if (arrayAndazeTolha[makanSath[i] - 2] !== undefined) {

                                    if (arrayAndazeTolha[makanSath[i] - 2] === 300) {

                                        if (anbarPlayt300 >= 7) {
                                            anbarPlayt300 = anbarPlayt300 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 250) {
                                        if (anbarPlayt250 >= 7) {
                                            anbarPlayt250 = anbarPlayt250 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 130) {
                                        if (anbarPlayt130 >= 7) {
                                            anbarPlayt130 = anbarPlayt130 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 100) {
                                        if (anbarPlayt100 >= 7) {
                                            anbarPlayt100 = anbarPlayt100 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 75) {
                                        if (anbarPlayt75 >= 7) {
                                            anbarPlayt75 = anbarPlayt75 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                }

                            }


                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 7) {
                                    anbarPlayt300 = anbarPlayt300 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 7) {
                                    anbarPlayt250 = anbarPlayt250 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 7) {
                                    anbarPlayt130 = anbarPlayt130 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 7) {
                                    anbarPlayt100 = anbarPlayt100 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 75) {
                                if (anbarPlayt75 >= 7) {
                                    anbarPlayt75 = anbarPlayt75 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }

                        }
                        else if (faseleDRCH[j] === 130) {
                            if (anbarKeshabi130 >= 2) {
                                anbarKeshabi130 = anbarKeshabi130 - 2;
                            } else {
                                resultMsg = false;
                            }

                            if (arrayAndazeTolha[makanSath[i] + 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] + 1] === 300) {

                                    if (anbarPlayt300 >= 4) {
                                        anbarPlayt300 = anbarPlayt300 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 250) {
                                    if (anbarPlayt250 >= 4) {
                                        anbarPlayt250 = anbarPlayt250 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 130) {
                                    if (anbarPlayt130 >= 4) {
                                        anbarPlayt130 = anbarPlayt130 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 100) {
                                    if (anbarPlayt100 >= 4) {
                                        anbarPlayt100 = anbarPlayt100 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 45) {
                                    if (anbarPlayt75 >= 4) {
                                        anbarPlayt75 = anbarPlayt75 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }

                                if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {

                                    if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                        if (anbarPlayt300 >= 4) {
                                            anbarPlayt300 = anbarPlayt300 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                        if (anbarPlayt250 >= 4) {
                                            anbarPlayt250 = anbarPlayt250 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                        if (anbarPlayt130 >= 4) {
                                            anbarPlayt130 = anbarPlayt130 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                        if (anbarPlayt100 >= 4) {
                                            anbarPlayt100 = anbarPlayt100 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 45) {
                                        if (anbarPlayt75 >= 4) {
                                            anbarPlayt75 = anbarPlayt75 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 2] !== undefined) {

                                    if (arrayAndazeTolha[makanSath[i] + 2] === 300) {

                                        if (anbarPlayt300 >= 4) {
                                            anbarPlayt300 = anbarPlayt300 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 250) {
                                        if (anbarPlayt250 >= 4) {
                                            anbarPlayt250 = anbarPlayt250 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 130) {
                                        if (anbarPlayt130 >= 4) {
                                            anbarPlayt130 = anbarPlayt130 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 100) {
                                        if (anbarPlayt100 >= 4) {
                                            anbarPlayt100 = anbarPlayt100 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 45) {
                                        if (anbarPlayt75 >= 4) {
                                            anbarPlayt75 = anbarPlayt75 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }

                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                    if (anbarPlayt300 >= 4) {
                                        anbarPlayt300 = anbarPlayt300 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                    if (anbarPlayt250 >= 4) {
                                        anbarPlayt250 = anbarPlayt250 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                    if (anbarPlayt130 >= 4) {
                                        anbarPlayt130 = anbarPlayt130 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                    if (anbarPlayt100 >= 4) {
                                        anbarPlayt100 = anbarPlayt100 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 45) {
                                    if (anbarPlayt75 >= 4) {
                                        anbarPlayt75 = anbarPlayt75 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }

                                if (arrayAndazeTolha[makanSath[i] - 2] !== undefined) {

                                    if (arrayAndazeTolha[makanSath[i] - 2] === 300) {

                                        if (anbarPlayt300 >= 4) {
                                            anbarPlayt300 = anbarPlayt300 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 250) {
                                        if (anbarPlayt250 >= 4) {
                                            anbarPlayt250 = anbarPlayt250 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 130) {
                                        if (anbarPlayt130 >= 4) {
                                            anbarPlayt130 = anbarPlayt130 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 100) {
                                        if (anbarPlayt100 >= 4) {
                                            anbarPlayt100 = anbarPlayt100 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 45) {
                                        if (anbarPlayt75 >= 4) {
                                            anbarPlayt75 = anbarPlayt75 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }

                                }


                            }


                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 4) {
                                    anbarPlayt300 = anbarPlayt300 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 4) {
                                    anbarPlayt250 = anbarPlayt250 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 4) {
                                    anbarPlayt130 = anbarPlayt130 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 4) {
                                    anbarPlayt100 = anbarPlayt100 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 45) {
                                if (anbarPlayt75 >= 4) {
                                    anbarPlayt75 = anbarPlayt75 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }


                        }
                        else if (faseleDRCH[j] === 100) {

                            if (anbarKeshabi100 >= 2) {
                                anbarKeshabi100 = anbarKeshabi100 - 2;
                            } else {
                                resultMsg = false;
                            }

                            if (arrayAndazeTolha[makanSath[i] + 1] !== undefined) {
                                if (arrayAndazeTolha[makanSath[i] + 1] === 300) {

                                    if (anbarPlayt300 >= 3) {
                                        anbarPlayt300 = anbarPlayt300 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 250) {
                                    if (anbarPlayt250 >= 3) {
                                        anbarPlayt250 = anbarPlayt250 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 130) {
                                    if (anbarPlayt130 >= 3) {
                                        anbarPlayt130 = anbarPlayt130 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 100) {
                                    if (anbarPlayt100 >= 3) {
                                        anbarPlayt100 = anbarPlayt100 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 75) {
                                    if (anbarPlayt75 >= 3) {
                                        anbarPlayt75 = anbarPlayt75 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }

                                if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {
                                    if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                        if (anbarPlayt300 >= 3) {
                                            anbarPlayt300 = anbarPlayt300 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                        if (anbarPlayt250 >= 3) {
                                            anbarPlayt250 = anbarPlayt250 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                        if (anbarPlayt130 >= 3) {
                                            anbarPlayt130 = anbarPlayt130 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                        if (anbarPlayt100 >= 3) {
                                            anbarPlayt100 = anbarPlayt100 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                                        if (anbarPlayt75 >= 3) {
                                            anbarPlayt75 = anbarPlayt75 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 2] !== undefined) {
                                    if (arrayAndazeTolha[makanSath[i] + 2] === 300) {

                                        if (anbarPlayt300 >= 3) {
                                            anbarPlayt300 = anbarPlayt300 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 250) {
                                        if (anbarPlayt250 >= 3) {
                                            anbarPlayt250 = anbarPlayt250 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 130) {
                                        if (anbarPlayt130 >= 3) {
                                            anbarPlayt130 = anbarPlayt130 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 100) {
                                        if (anbarPlayt100 >= 3) {
                                            anbarPlayt100 = anbarPlayt100 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 75) {
                                        if (anbarPlayt75 >= 3) {
                                            anbarPlayt75 = anbarPlayt75 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                }


                            }
                            else if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {
                                if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                    if (anbarPlayt300 >= 3) {
                                        anbarPlayt300 = anbarPlayt300 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                    if (anbarPlayt250 >= 3) {
                                        anbarPlayt250 = anbarPlayt250 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                    if (anbarPlayt130 >= 3) {
                                        anbarPlayt130 = anbarPlayt130 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                    if (anbarPlayt100 >= 3) {
                                        anbarPlayt100 = anbarPlayt100 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                                    if (anbarPlayt75 >= 3) {
                                        anbarPlayt75 = anbarPlayt75 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }

                                if (arrayAndazeTolha[makanSath[i] - 2] !== undefined) {
                                    if (arrayAndazeTolha[makanSath[i] - 2] === 300) {

                                        if (anbarPlayt300 >= 3) {
                                            anbarPlayt300 = anbarPlayt300 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 250) {
                                        if (anbarPlayt250 >= 3) {
                                            anbarPlayt250 = anbarPlayt250 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 130) {
                                        if (anbarPlayt130 >= 3) {
                                            anbarPlayt130 = anbarPlayt130 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 100) {
                                        if (anbarPlayt100 >= 3) {
                                            anbarPlayt100 = anbarPlayt100 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 75) {
                                        if (anbarPlayt75 >= 3) {
                                            anbarPlayt75 = anbarPlayt75 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }

                                }

                            }


                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 3) {
                                    anbarPlayt300 = anbarPlayt300 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 3) {
                                    anbarPlayt250 = anbarPlayt250 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 3) {
                                    anbarPlayt130 = anbarPlayt130 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 3) {
                                    anbarPlayt100 = anbarPlayt100 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 75) {
                                if (anbarPlayt75 >= 3) {
                                    anbarPlayt75 = anbarPlayt75 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }

                        }
                        else if (faseleDRCH[j] === 75) {


                            if (anbarKeshabi75 >= 2) {
                                anbarKeshabi75 = anbarKeshabi75 - 2;


                            } else {
                                resultMsg = false;
                            }

                            if (arrayAndazeTolha[makanSath[i] + 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] + 1] === 300) {

                                    if (anbarPlayt300 >= 2) {
                                        anbarPlayt300 = anbarPlayt300 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 250) {
                                    if (anbarPlayt250 >= 2) {
                                        anbarPlayt250 = anbarPlayt250 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 130) {
                                    if (anbarPlayt130 >= 2) {
                                        anbarPlayt130 = anbarPlayt130 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 100) {
                                    if (anbarPlayt100 >= 2) {
                                        anbarPlayt100 = anbarPlayt100 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 75) {
                                    if (anbarPlayt75 >= 2) {
                                        anbarPlayt75 = anbarPlayt75 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }

                                if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {

                                    if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                        if (anbarPlayt300 >= 2) {
                                            anbarPlayt300 = anbarPlayt300 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                        if (anbarPlayt250 >= 2) {
                                            anbarPlayt250 = anbarPlayt250 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                        if (anbarPlayt130 >= 2) {
                                            anbarPlayt130 = anbarPlayt130 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                        if (anbarPlayt100 >= 2) {
                                            anbarPlayt100 = anbarPlayt100 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                                        if (anbarPlayt75 >= 2) {
                                            anbarPlayt75 = anbarPlayt75 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 2] !== undefined) {

                                    if (arrayAndazeTolha[makanSath[i] + 2] === 300) {

                                        if (anbarPlayt300 >= 2) {
                                            anbarPlayt300 = anbarPlayt300 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 250) {
                                        if (anbarPlayt250 >= 2) {
                                            anbarPlayt250 = anbarPlayt250 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 130) {
                                        if (anbarPlayt130 >= 2) {
                                            anbarPlayt130 = anbarPlayt130 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 100) {
                                        if (anbarPlayt100 >= 2) {
                                            anbarPlayt100 = anbarPlayt100 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 75) {
                                        if (anbarPlayt75 >= 2) {
                                            anbarPlayt75 = anbarPlayt75 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                    if (anbarPlayt300 >= 2) {
                                        anbarPlayt300 = anbarPlayt300 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                    if (anbarPlayt250 >= 2) {
                                        anbarPlayt250 = anbarPlayt250 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                    if (anbarPlayt130 >= 2) {
                                        anbarPlayt130 = anbarPlayt130 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                    if (anbarPlayt100 >= 2) {
                                        anbarPlayt100 = anbarPlayt100 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                                    if (anbarPlayt75 >= 2) {
                                        anbarPlayt75 = anbarPlayt75 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }

                                if (arrayAndazeTolha[makanSath[i] - 2] !== undefined) {

                                    if (arrayAndazeTolha[makanSath[i] - 2] === 300) {

                                        if (anbarPlayt300 >= 2) {
                                            anbarPlayt300 = anbarPlayt300 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 250) {
                                        if (anbarPlayt250 >= 2) {
                                            anbarPlayt250 = anbarPlayt250 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 130) {
                                        if (anbarPlayt130 >= 2) {
                                            anbarPlayt130 = anbarPlayt130 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 100) {
                                        if (anbarPlayt100 >= 2) {
                                            anbarPlayt100 = anbarPlayt100 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 75) {
                                        if (anbarPlayt75 >= 2) {
                                            anbarPlayt75 = anbarPlayt75 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                }

                            }


                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 2) {
                                    anbarPlayt300 = anbarPlayt300 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 2) {
                                    anbarPlayt250 = anbarPlayt250 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 2) {
                                    anbarPlayt130 = anbarPlayt130 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 2) {
                                    anbarPlayt100 = anbarPlayt100 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 75) {
                                if (anbarPlayt75 >= 2) {
                                    anbarPlayt75 = anbarPlayt75 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                        }
                    }
                    else {

                        if (faseleDRCH[j] === 300) {
                            if (anbarKeshabi300 >= 4) {
                                anbarKeshabi300 = anbarKeshabi300 - 4;
                            }
                            else {
                                resultMsg = false;
                            }
                            if (arrayAndazeTolha[makanSath[i] + 1] !== undefined) {


                                if (arrayAndazeTolha[makanSath[i] + 1] === 300) {

                                    if (anbarPlayt300 >= 9) {
                                        anbarPlayt300 = anbarPlayt300 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 250) {
                                    if (anbarPlayt250 >= 9) {
                                        anbarPlayt250 = anbarPlayt250 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 130) {
                                    if (anbarPlayt130 >= 9) {
                                        anbarPlayt130 = anbarPlayt130 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 100) {
                                    if (anbarPlayt100 >= 9) {
                                        anbarPlayt100 = anbarPlayt100 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 75) {
                                    if (anbarPlayt75 >= 9) {
                                        anbarPlayt75 = anbarPlayt75 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }

                                if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {


                                    if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                        if (anbarPlayt300 >= 9) {
                                            anbarPlayt300 = anbarPlayt300 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                        if (anbarPlayt250 >= 9) {
                                            anbarPlayt250 = anbarPlayt250 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                        if (anbarPlayt130 >= 9) {
                                            anbarPlayt130 = anbarPlayt130 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                        if (anbarPlayt100 >= 9) {
                                            anbarPlayt100 = anbarPlayt100 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                                        if (anbarPlayt75 >= 9) {
                                            anbarPlayt75 = anbarPlayt75 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 2] !== undefined) {

                                    if (arrayAndazeTolha[makanSath[i] + 2] === 300) {

                                        if (anbarPlayt300 >= 9) {
                                            anbarPlayt300 = anbarPlayt300 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 250) {
                                        if (anbarPlayt250 >= 9) {
                                            anbarPlayt250 = anbarPlayt250 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 130) {
                                        if (anbarPlayt130 >= 9) {
                                            anbarPlayt130 = anbarPlayt130 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 100) {
                                        if (anbarPlayt100 >= 9) {
                                            anbarPlayt100 = anbarPlayt100 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 75) {
                                        if (anbarPlayt75 >= 9) {
                                            anbarPlayt75 = anbarPlayt75 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {


                                if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                    if (anbarPlayt300 >= 9) {
                                        anbarPlayt300 = anbarPlayt300 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                    if (anbarPlayt250 >= 9) {
                                        anbarPlayt250 = anbarPlayt250 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                    if (anbarPlayt130 >= 9) {
                                        anbarPlayt130 = anbarPlayt130 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                    if (anbarPlayt100 >= 9) {
                                        anbarPlayt100 = anbarPlayt100 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                                    if (anbarPlayt75 >= 9) {
                                        anbarPlayt75 = anbarPlayt75 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }

                                if (arrayAndazeTolha[makanSath[i] - 2] !== undefined) {


                                    if (arrayAndazeTolha[makanSath[i] - 2] === 300) {

                                        if (anbarPlayt300 >= 9) {
                                            anbarPlayt300 = anbarPlayt300 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 250) {
                                        if (anbarPlayt250 >= 9) {
                                            anbarPlayt250 = anbarPlayt250 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 130) {
                                        if (anbarPlayt130 >= 9) {
                                            anbarPlayt130 = anbarPlayt130 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 100) {
                                        if (anbarPlayt100 >= 9) {
                                            anbarPlayt100 = anbarPlayt100 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 75) {
                                        if (anbarPlayt75 >= 9) {
                                            anbarPlayt75 = anbarPlayt75 - 9;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                }
                            }


                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 9) {
                                    anbarPlayt300 = anbarPlayt300 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 9) {
                                    anbarPlayt250 = anbarPlayt250 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 9) {
                                    anbarPlayt130 = anbarPlayt130 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 9) {
                                    anbarPlayt100 = anbarPlayt100 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 75) {
                                if (anbarPlayt75 >= 9) {
                                    anbarPlayt75 = anbarPlayt75 - 9;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }

                        }
                        else if (faseleDRCH[j] === 250) {
                            if (anbarKeshabi250 >= 4) {
                                anbarKeshabi250 = anbarKeshabi250 - 4;


                            } else {
                                resultMsg = false;
                            }

                            if (arrayAndazeTolha[makanSath[i] + 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] + 1] === 300) {

                                    if (anbarPlayt300 >= 7) {
                                        anbarPlayt300 = anbarPlayt300 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 250) {
                                    if (anbarPlayt250 >= 7) {
                                        anbarPlayt250 = anbarPlayt250 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 130) {
                                    if (anbarPlayt130 >= 7) {
                                        anbarPlayt130 = anbarPlayt130 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 100) {
                                    if (anbarPlayt100 >= 7) {
                                        anbarPlayt100 = anbarPlayt100 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 75) {
                                    if (anbarPlayt75 >= 7) {
                                        anbarPlayt75 = anbarPlayt75 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }

                                if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {

                                    if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                        if (anbarPlayt300 >= 7) {
                                            anbarPlayt300 = anbarPlayt300 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                        if (anbarPlayt250 >= 7) {
                                            anbarPlayt250 = anbarPlayt250 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                        if (anbarPlayt130 >= 7) {
                                            anbarPlayt130 = anbarPlayt130 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                        if (anbarPlayt100 >= 7) {
                                            anbarPlayt100 = anbarPlayt100 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                                        if (anbarPlayt75 >= 7) {
                                            anbarPlayt75 = anbarPlayt75 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 2] !== undefined) {

                                    if (arrayAndazeTolha[makanSath[i] + 2] === 300) {

                                        if (anbarPlayt300 >= 7) {
                                            anbarPlayt300 = anbarPlayt300 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 250) {
                                        if (anbarPlayt250 >= 7) {
                                            anbarPlayt250 = anbarPlayt250 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 130) {
                                        if (anbarPlayt130 >= 7) {
                                            anbarPlayt130 = anbarPlayt130 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 100) {
                                        if (anbarPlayt100 >= 7) {
                                            anbarPlayt100 = anbarPlayt100 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 75) {
                                        if (anbarPlayt75 >= 7) {
                                            anbarPlayt75 = anbarPlayt75 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                    if (anbarPlayt300 >= 7) {
                                        anbarPlayt300 = anbarPlayt300 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                    if (anbarPlayt250 >= 7) {
                                        anbarPlayt250 = anbarPlayt250 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                    if (anbarPlayt130 >= 7) {
                                        anbarPlayt130 = anbarPlayt130 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                    if (anbarPlayt100 >= 7) {
                                        anbarPlayt100 = anbarPlayt100 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                                    if (anbarPlayt75 >= 7) {
                                        anbarPlayt75 = anbarPlayt75 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                if (arrayAndazeTolha[makanSath[i] - 2] !== undefined) {

                                    if (arrayAndazeTolha[makanSath[i] - 2] === 300) {

                                        if (anbarPlayt300 >= 7) {
                                            anbarPlayt300 = anbarPlayt300 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 250) {
                                        if (anbarPlayt250 >= 7) {
                                            anbarPlayt250 = anbarPlayt250 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 130) {
                                        if (anbarPlayt130 >= 7) {
                                            anbarPlayt130 = anbarPlayt130 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 100) {
                                        if (anbarPlayt100 >= 7) {
                                            anbarPlayt100 = anbarPlayt100 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 75) {
                                        if (anbarPlayt75 >= 7) {
                                            anbarPlayt75 = anbarPlayt75 - 7;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                }

                            }
                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 7) {
                                    anbarPlayt300 = anbarPlayt300 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 7) {
                                    anbarPlayt250 = anbarPlayt250 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 7) {
                                    anbarPlayt130 = anbarPlayt130 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 7) {
                                    anbarPlayt100 = anbarPlayt100 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 75) {
                                if (anbarPlayt75 >= 7) {
                                    anbarPlayt75 = anbarPlayt75 - 7;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }

                        }
                        else if (faseleDRCH[j] === 130) {
                            if (anbarKeshabi130 >= 4) {
                                anbarKeshabi130 = anbarKeshabi130 - 4;
                            } else {
                                resultMsg = false;
                            }
                            if (arrayAndazeTolha[makanSath[i] + 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] + 1] === 300) {

                                    if (anbarPlayt300 >= 4) {
                                        anbarPlayt300 = anbarPlayt300 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 250) {
                                    if (anbarPlayt250 >= 4) {
                                        anbarPlayt250 = anbarPlayt250 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 130) {
                                    if (anbarPlayt130 >= 4) {
                                        anbarPlayt130 = anbarPlayt130 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 100) {
                                    if (anbarPlayt100 >= 4) {
                                        anbarPlayt100 = anbarPlayt100 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 45) {
                                    if (anbarPlayt75 >= 4) {
                                        anbarPlayt75 = anbarPlayt75 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }

                                if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {

                                    if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                        if (anbarPlayt300 >= 4) {
                                            anbarPlayt300 = anbarPlayt300 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                        if (anbarPlayt250 >= 4) {
                                            anbarPlayt250 = anbarPlayt250 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                        if (anbarPlayt130 >= 4) {
                                            anbarPlayt130 = anbarPlayt130 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                        if (anbarPlayt100 >= 4) {
                                            anbarPlayt100 = anbarPlayt100 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 45) {
                                        if (anbarPlayt75 >= 4) {
                                            anbarPlayt75 = anbarPlayt75 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 2] !== undefined) {

                                    if (arrayAndazeTolha[makanSath[i] + 2] === 300) {

                                        if (anbarPlayt300 >= 4) {
                                            anbarPlayt300 = anbarPlayt300 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 250) {
                                        if (anbarPlayt250 >= 4) {
                                            anbarPlayt250 = anbarPlayt250 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 130) {
                                        if (anbarPlayt130 >= 4) {
                                            anbarPlayt130 = anbarPlayt130 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 100) {
                                        if (anbarPlayt100 >= 4) {
                                            anbarPlayt100 = anbarPlayt100 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 45) {
                                        if (anbarPlayt75 >= 4) {
                                            anbarPlayt75 = anbarPlayt75 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }

                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                    if (anbarPlayt300 >= 4) {
                                        anbarPlayt300 = anbarPlayt300 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                    if (anbarPlayt250 >= 4) {
                                        anbarPlayt250 = anbarPlayt250 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                    if (anbarPlayt130 >= 4) {
                                        anbarPlayt130 = anbarPlayt130 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                    if (anbarPlayt100 >= 4) {
                                        anbarPlayt100 = anbarPlayt100 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 45) {
                                    if (anbarPlayt75 >= 4) {
                                        anbarPlayt75 = anbarPlayt75 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }

                                if (arrayAndazeTolha[makanSath[i] - 2] !== undefined) {

                                    if (arrayAndazeTolha[makanSath[i] - 2] === 300) {

                                        if (anbarPlayt300 >= 4) {
                                            anbarPlayt300 = anbarPlayt300 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 250) {
                                        if (anbarPlayt250 >= 4) {
                                            anbarPlayt250 = anbarPlayt250 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 130) {
                                        if (anbarPlayt130 >= 4) {
                                            anbarPlayt130 = anbarPlayt130 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 100) {
                                        if (anbarPlayt100 >= 4) {
                                            anbarPlayt100 = anbarPlayt100 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 45) {
                                        if (anbarPlayt75 >= 4) {
                                            anbarPlayt75 = anbarPlayt75 - 4;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }

                                }


                            }

                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 4) {
                                    anbarPlayt300 = anbarPlayt300 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 4) {
                                    anbarPlayt250 = anbarPlayt250 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 4) {
                                    anbarPlayt130 = anbarPlayt130 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 4) {
                                    anbarPlayt100 = anbarPlayt100 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 45) {
                                if (anbarPlayt75 >= 4) {
                                    anbarPlayt75 = anbarPlayt75 - 4;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }


                        }
                        else if (faseleDRCH[j] === 100) {
                            if (anbarKeshabi100 >= 4) {
                                anbarKeshabi100 = anbarKeshabi100 - 4;
                            } else {
                                resultMsg = false;
                            }
                            if (arrayAndazeTolha[makanSath[i] + 1] !== undefined) {
                                if (arrayAndazeTolha[makanSath[i] + 1] === 300) {

                                    if (anbarPlayt300 >= 3) {
                                        anbarPlayt300 = anbarPlayt300 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 250) {
                                    if (anbarPlayt250 >= 3) {
                                        anbarPlayt250 = anbarPlayt250 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 130) {
                                    if (anbarPlayt130 >= 3) {
                                        anbarPlayt130 = anbarPlayt130 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 100) {
                                    if (anbarPlayt100 >= 3) {
                                        anbarPlayt100 = anbarPlayt100 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 75) {
                                    if (anbarPlayt75 >= 3) {
                                        anbarPlayt75 = anbarPlayt75 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }

                                if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {
                                    if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                        if (anbarPlayt300 >= 3) {
                                            anbarPlayt300 = anbarPlayt300 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                        if (anbarPlayt250 >= 3) {
                                            anbarPlayt250 = anbarPlayt250 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                        if (anbarPlayt130 >= 3) {
                                            anbarPlayt130 = anbarPlayt130 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                        if (anbarPlayt100 >= 3) {
                                            anbarPlayt100 = anbarPlayt100 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                                        if (anbarPlayt75 >= 3) {
                                            anbarPlayt75 = anbarPlayt75 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 2] !== undefined) {
                                    if (arrayAndazeTolha[makanSath[i] + 2] === 300) {

                                        if (anbarPlayt300 >= 3) {
                                            anbarPlayt300 = anbarPlayt300 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 250) {
                                        if (anbarPlayt250 >= 3) {
                                            anbarPlayt250 = anbarPlayt250 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 130) {
                                        if (anbarPlayt130 >= 3) {
                                            anbarPlayt130 = anbarPlayt130 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 100) {
                                        if (anbarPlayt100 >= 3) {
                                            anbarPlayt100 = anbarPlayt100 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 75) {
                                        if (anbarPlayt75 >= 3) {
                                            anbarPlayt75 = anbarPlayt75 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                }


                            }
                            else if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {
                                if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                    if (anbarPlayt300 >= 3) {
                                        anbarPlayt300 = anbarPlayt300 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                    if (anbarPlayt250 >= 3) {
                                        anbarPlayt250 = anbarPlayt250 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                    if (anbarPlayt130 >= 3) {
                                        anbarPlayt130 = anbarPlayt130 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                    if (anbarPlayt100 >= 3) {
                                        anbarPlayt100 = anbarPlayt100 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                                    if (anbarPlayt75 >= 3) {
                                        anbarPlayt75 = anbarPlayt75 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }

                                if (arrayAndazeTolha[makanSath[i] - 2] !== undefined) {
                                    if (arrayAndazeTolha[makanSath[i] - 2] === 300) {

                                        if (anbarPlayt300 >= 3) {
                                            anbarPlayt300 = anbarPlayt300 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 250) {
                                        if (anbarPlayt250 >= 3) {
                                            anbarPlayt250 = anbarPlayt250 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 130) {
                                        if (anbarPlayt130 >= 3) {
                                            anbarPlayt130 = anbarPlayt130 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 100) {
                                        if (anbarPlayt100 >= 3) {
                                            anbarPlayt100 = anbarPlayt100 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 75) {
                                        if (anbarPlayt75 >= 3) {
                                            anbarPlayt75 = anbarPlayt75 - 3;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }

                                }

                            }
                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 3) {
                                    anbarPlayt300 = anbarPlayt300 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 3) {
                                    anbarPlayt250 = anbarPlayt250 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 3) {
                                    anbarPlayt130 = anbarPlayt130 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 3) {
                                    anbarPlayt100 = anbarPlayt100 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 75) {
                                if (anbarPlayt75 >= 3) {
                                    anbarPlayt75 = anbarPlayt75 - 3;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }

                        }
                        else if (faseleDRCH[j] === 75) {
                            if (anbarKeshabi75 >= 4) {
                                anbarKeshabi75 = anbarKeshabi75 - 4;


                            } else {
                                resultMsg = false;
                            }

                            if (arrayAndazeTolha[makanSath[i] + 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] + 1] === 300) {

                                    if (anbarPlayt300 >= 2) {
                                        anbarPlayt300 = anbarPlayt300 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 250) {
                                    if (anbarPlayt250 >= 2) {
                                        anbarPlayt250 = anbarPlayt250 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 130) {
                                    if (anbarPlayt130 >= 2) {
                                        anbarPlayt130 = anbarPlayt130 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 100) {
                                    if (anbarPlayt100 >= 2) {
                                        anbarPlayt100 = anbarPlayt100 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] + 1] === 75) {
                                    if (anbarPlayt75 >= 2) {
                                        anbarPlayt75 = anbarPlayt75 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }

                                if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {

                                    if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                        if (anbarPlayt300 >= 2) {
                                            anbarPlayt300 = anbarPlayt300 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                        if (anbarPlayt250 >= 2) {
                                            anbarPlayt250 = anbarPlayt250 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                        if (anbarPlayt130 >= 2) {
                                            anbarPlayt130 = anbarPlayt130 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                        if (anbarPlayt100 >= 2) {
                                            anbarPlayt100 = anbarPlayt100 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                                        if (anbarPlayt75 >= 2) {
                                            anbarPlayt75 = anbarPlayt75 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] + 2] !== undefined) {

                                    if (arrayAndazeTolha[makanSath[i] + 2] === 300) {

                                        if (anbarPlayt300 >= 2) {
                                            anbarPlayt300 = anbarPlayt300 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 250) {
                                        if (anbarPlayt250 >= 2) {
                                            anbarPlayt250 = anbarPlayt250 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 130) {
                                        if (anbarPlayt130 >= 2) {
                                            anbarPlayt130 = anbarPlayt130 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 100) {
                                        if (anbarPlayt100 >= 2) {
                                            anbarPlayt100 = anbarPlayt100 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] + 2] === 75) {
                                        if (anbarPlayt75 >= 2) {
                                            anbarPlayt75 = anbarPlayt75 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {

                                if (arrayAndazeTolha[makanSath[i] - 1] === 300) {

                                    if (anbarPlayt300 >= 2) {
                                        anbarPlayt300 = anbarPlayt300 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                                    if (anbarPlayt250 >= 2) {
                                        anbarPlayt250 = anbarPlayt250 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                                    if (anbarPlayt130 >= 2) {
                                        anbarPlayt130 = anbarPlayt130 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                                    if (anbarPlayt100 >= 2) {
                                        anbarPlayt100 = anbarPlayt100 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                                    if (anbarPlayt75 >= 2) {
                                        anbarPlayt75 = anbarPlayt75 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }

                                if (arrayAndazeTolha[makanSath[i] - 2] !== undefined) {

                                    if (arrayAndazeTolha[makanSath[i] - 2] === 300) {

                                        if (anbarPlayt300 >= 2) {
                                            anbarPlayt300 = anbarPlayt300 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }
                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 250) {
                                        if (anbarPlayt250 >= 2) {
                                            anbarPlayt250 = anbarPlayt250 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 130) {
                                        if (anbarPlayt130 >= 2) {
                                            anbarPlayt130 = anbarPlayt130 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 100) {
                                        if (anbarPlayt100 >= 2) {
                                            anbarPlayt100 = anbarPlayt100 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                    else if (arrayAndazeTolha[makanSath[i] - 2] === 75) {
                                        if (anbarPlayt75 >= 2) {
                                            anbarPlayt75 = anbarPlayt75 - 2;
                                        }
                                        else {
                                            resultMsg = false;
                                        }

                                    }
                                }

                            }

                            if (arrayAndazeTolha[makanSath[i]] === 300) {

                                if (anbarPlayt300 >= 2) {
                                    anbarPlayt300 = anbarPlayt300 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }
                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 250) {
                                if (anbarPlayt250 >= 2) {
                                    anbarPlayt250 = anbarPlayt250 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 130) {
                                if (anbarPlayt130 >= 2) {
                                    anbarPlayt130 = anbarPlayt130 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 100) {
                                if (anbarPlayt100 >= 2) {
                                    anbarPlayt100 = anbarPlayt100 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                            else if (arrayAndazeTolha[makanSath[i]] === 75) {
                                if (anbarPlayt75 >= 2) {
                                    anbarPlayt75 = anbarPlayt75 - 2;
                                }
                                else {
                                    resultMsg = false;
                                }

                            }
                        }
                    }


                }


                var makanSathF = 0;
                if (arrayAndazeTolha[makanSath[i] + 1] === undefined) {
                    makanSathF = makanSath[i - 2];

                }
                else {
                    if (arrayAndazeTolha[makanSath[i] - 1] === undefined) {
                        makanSathF = makanSath[i];

                    } else {
                        makanSathF = makanSath[i - 1];

                    }


                }
                for (g = 1; g < makanSathF; g++) {

                    if (g !== 1) {
                        var n = chekeHeght.includes(heightMSD1[i] + "" + g);
                        if (n === false) {

                            if (arrayAndazeTolha[g] === 300) {
                                if (anbarKeshabi300 >= 4) {
                                    anbarKeshabi300 = anbarKeshabi300 - 4;

                                } else {
                                    resultMsg = false;
                                }

                                if (faseleDRCH[0] === 300) {

                                    if (anbarPlayt300 >= 9) {
                                        anbarPlayt300 = anbarPlayt300 - 9;
                                    } else {
                                        resultMsg = false;
                                    }
                                }
                                else if (faseleDRCH[0] === 250) {
                                    if (anbarPlayt300 >= 7) {
                                        anbarPlayt300 = anbarPlayt300 - 7;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 130) {
                                    if (anbarPlayt300 >= 4) {
                                        anbarPlayt300 = anbarPlayt300 - 4;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 100) {
                                    if (anbarPlayt300 >= 3) {
                                        anbarPlayt300 = anbarPlayt300 - 3;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 75) {
                                    if (anbarPlayt300 >= 2) {
                                        anbarPlayt300 = anbarPlayt300 - 2;
                                    } else {
                                        resultMsg = false;
                                    }

                                }


                            }

                            else if (arrayAndazeTolha[g] === 250) {
                                if (anbarKeshabi250 >= 4) {
                                    anbarKeshabi250 = anbarKeshabi250 - 4;

                                } else {
                                    resultMsg = false;
                                }

                                if (faseleDRCH[0] === 300) {

                                    if (anbarPlayt250 >= 9) {
                                        anbarPlayt250 = anbarPlayt250 - 9;
                                    } else {
                                        resultMsg = false;
                                    }
                                }
                                else if (faseleDRCH[0] === 250) {
                                    if (anbarPlayt250 >= 7) {
                                        anbarPlayt250 = anbarPlayt250 - 7;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 130) {
                                    if (anbarPlayt250 >= 4) {
                                        anbarPlayt250 = anbarPlayt250 - 4;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 100) {
                                    if (anbarPlayt250 >= 3) {
                                        anbarPlayt250 = anbarPlayt250 - 3;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 75) {
                                    if (anbarPlayt250 >= 2) {
                                        anbarPlayt250 = anbarPlayt250 - 2;
                                    } else {
                                        resultMsg = false;
                                    }

                                }


                            }

                            else if (arrayAndazeTolha[g] === 130) {
                                if (anbarKeshabi130 >= 4) {
                                    anbarKeshabi130 = anbarKeshabi130 - 4;
                                } else {
                                    resultMsg = false;
                                }
                                if (faseleDRCH[0] === 300) {

                                    if (anbarPlayt130 >= 9) {
                                        anbarPlayt130 = anbarPlayt130 - 9;
                                    } else {
                                        resultMsg = false;
                                    }
                                }
                                else if (faseleDRCH[0] === 250) {
                                    if (anbarPlayt130 >= 7) {
                                        anbarPlayt130 = anbarPlayt130 - 7;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 130) {
                                    if (anbarPlayt130 >= 4) {
                                        anbarPlayt130 = anbarPlayt130 - 4;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 100) {
                                    if (anbarPlayt130 >= 3) {
                                        anbarPlayt130 = anbarPlayt130 - 3;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 75) {
                                    if (anbarPlayt130 >= 2) {
                                        anbarPlayt130 = anbarPlayt130 - 2;
                                    } else {
                                        resultMsg = false;
                                    }

                                }


                            }

                            else if (arrayAndazeTolha[g] === 100) {
                                if (anbarKeshabi100 >= 4) {
                                    anbarKeshabi100 = anbarKeshabi100 - 4;

                                } else {
                                    resultMsg = false;
                                }

                                if (faseleDRCH[0] === 300) {

                                    if (anbarPlayt100 >= 9) {
                                        anbarPlayt100 = anbarPlayt100 - 9;
                                    } else {
                                        resultMsg = false;
                                    }
                                }
                                else if (faseleDRCH[0] === 250) {
                                    if (anbarPlayt100 >= 7) {
                                        anbarPlayt100 = anbarPlayt100 - 7;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 130) {
                                    if (anbarPlayt100 >= 4) {
                                        anbarPlayt100 = anbarPlayt100 - 4;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 100) {
                                    if (anbarPlayt100 >= 3) {
                                        anbarPlayt100 = anbarPlayt100 - 3;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 75) {
                                    if (anbarPlayt100 >= 2) {
                                        anbarPlayt100 = anbarPlayt100 - 2;
                                    } else {
                                        resultMsg = false;
                                    }

                                }

                            }

                            else if (arrayAndazeTolha[g] === 75) {
                                if (anbarKeshabi75 >= 4) {
                                    anbarKeshabi75 = anbarKeshabi75 - 4;

                                } else {
                                    resultMsg = false;
                                }
                                if (faseleDRCH[0] === 300) {

                                    if (anbarPlayt75 >= 9) {
                                        anbarPlayt75 = anbarPlayt75 - 9;
                                    } else {
                                        resultMsg = false;
                                    }
                                }
                                else if (faseleDRCH[0] === 250) {
                                    if (anbarPlayt75 >= 7) {
                                        anbarPlayt75 = anbarPlayt75 - 7;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 130) {
                                    if (anbarPlayt75 >= 4) {
                                        anbarPlayt75 = anbarPlayt75 - 4;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 100) {
                                    if (anbarPlayt75 >= 3) {
                                        anbarPlayt75 = anbarPlayt75 - 3;
                                    } else {
                                        resultMsg = false;
                                    }

                                }
                                else if (faseleDRCH[0] === 75) {
                                    if (anbarPlayt75 >= 2) {
                                        anbarPlayt75 = anbarPlayt75 - 2;
                                    } else {
                                        resultMsg = false;
                                    }

                                }


                            }

                        }
                    }
                    chekeHeght.push(heightMSD1[i] + "" + g)


                }


                if (arrayAndazeTolha[makanSath[i] + 1] !== undefined) {

                    if (arrayAndazeTolha[makanSath[i] + 1] === 300) {
                        if (anbarKeshabi300 >= 4) {
                            anbarKeshabi300 = anbarKeshabi300 - 4;

                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[makanSath[i] + 1] === 250) {
                        if (anbarKeshabi250 >= 4) {
                            anbarKeshabi250 = anbarKeshabi250 - 4;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[makanSath[i] + 1] === 130) {
                        if (anbarKeshabi130 >= 4) {
                            anbarKeshabi130 = anbarKeshabi130 - 4;

                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[makanSath[i] + 1] === 100) {
                        if (anbarKeshabi100 >= 4) {
                            anbarKeshabi100 = anbarKeshabi100 - 4;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[makanSath[i] + 1] === 75) {
                        if (anbarKeshabi75 >= 4) {
                            anbarKeshabi75 = anbarKeshabi75 - 4;


                        } else {
                            resultMsg = false;
                        }

                    }


                    if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {

                        if (arrayAndazeTolha[makanSath[i] - 1] === 300) {
                            if (anbarKeshabi300 >= 4) {
                                anbarKeshabi300 = anbarKeshabi300 - 4;

                            } else {
                                resultMsg = false;
                            }

                        }
                        else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                            if (anbarKeshabi250 >= 4) {
                                anbarKeshabi250 = anbarKeshabi250 - 4;


                            } else {
                                resultMsg = false;
                            }

                        }
                        else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                            if (anbarKeshabi130 >= 4) {
                                anbarKeshabi130 = anbarKeshabi130 - 4;

                            } else {
                                resultMsg = false;
                            }

                        }
                        else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                            if (anbarKeshabi100 >= 4) {
                                anbarKeshabi100 = anbarKeshabi100 - 4;


                            } else {
                                resultMsg = false;
                            }

                        }
                        else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                            if (anbarKeshabi75 >= 4) {
                                anbarKeshabi75 = anbarKeshabi75 - 4;


                            } else {
                                resultMsg = false;
                            }

                        }


                    }
                    else if (arrayAndazeTolha[makanSath[i] + 2] !== undefined) {

                        if (arrayAndazeTolha[makanSath[i] + 2] === 300) {
                            if (anbarKeshabi300 >= 4) {
                                anbarKeshabi300 = anbarKeshabi300 - 4;

                            } else {
                                resultMsg = false;
                            }

                        }
                        else if (arrayAndazeTolha[makanSath[i] + 2] === 250) {
                            if (anbarKeshabi250 >= 4) {
                                anbarKeshabi250 = anbarKeshabi250 - 4;


                            } else {
                                resultMsg = false;
                            }

                        }
                        else if (arrayAndazeTolha[makanSath[i] + 2] === 130) {
                            if (anbarKeshabi130 >= 4) {
                                anbarKeshabi130 = anbarKeshabi130 - 4;

                            } else {
                                resultMsg = false;
                            }

                        }
                        else if (arrayAndazeTolha[makanSath[i] + 2] === 100) {
                            if (anbarKeshabi100 >= 4) {
                                anbarKeshabi100 = anbarKeshabi100 - 4;


                            } else {
                                resultMsg = false;
                            }

                        }
                        else if (arrayAndazeTolha[makanSath[i] + 2] === 75) {
                            if (anbarKeshabi75 >= 4) {
                                anbarKeshabi75 = anbarKeshabi75 - 4;


                            } else {
                                resultMsg = false;
                            }

                        }
                    }


                }
                else if (arrayAndazeTolha[makanSath[i] - 1] !== undefined) {
                    if (arrayAndazeTolha[makanSath[i] - 1] === 300) {
                        if (anbarKeshabi300 >= 4) {
                            anbarKeshabi300 = anbarKeshabi300 - 4;

                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[makanSath[i] - 1] === 250) {
                        if (anbarKeshabi250 >= 4) {
                            anbarKeshabi250 = anbarKeshabi250 - 4;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[makanSath[i] - 1] === 130) {
                        if (anbarKeshabi130 >= 4) {
                            anbarKeshabi130 = anbarKeshabi130 - 4;

                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[makanSath[i] - 1] === 100) {
                        if (anbarKeshabi100 >= 4) {
                            anbarKeshabi100 = anbarKeshabi100 - 4;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[makanSath[i] - 1] === 75) {
                        if (anbarKeshabi75 >= 4) {
                            anbarKeshabi75 = anbarKeshabi75 - 4;


                        } else {
                            resultMsg = false;
                        }

                    }


                    if (arrayAndazeTolha[makanSath[i] - 2] !== undefined) {
                        if (arrayAndazeTolha[makanSath[i] - 2] === 300) {
                            if (anbarKeshabi300 >= 4) {
                                anbarKeshabi300 = anbarKeshabi300 - 4;

                            } else {
                                resultMsg = false;
                            }

                        }
                        else if (arrayAndazeTolha[makanSath[i] - 2] === 250) {
                            if (anbarKeshabi250 >= 4) {
                                anbarKeshabi250 = anbarKeshabi250 - 4;


                            } else {
                                resultMsg = false;
                            }

                        }
                        else if (arrayAndazeTolha[makanSath[i] - 2] === 130) {
                            if (anbarKeshabi130 >= 4) {
                                anbarKeshabi130 = anbarKeshabi130 - 4;

                            } else {
                                resultMsg = false;
                            }

                        }
                        else if (arrayAndazeTolha[makanSath[i] - 2] === 100) {
                            if (anbarKeshabi100 >= 4) {
                                anbarKeshabi100 = anbarKeshabi100 - 4;


                            } else {
                                resultMsg = false;
                            }

                        }
                        else if (arrayAndazeTolha[makanSath[i] - 2] === 75) {
                            if (anbarKeshabi75 >= 4) {
                                anbarKeshabi75 = anbarKeshabi75 - 4;


                            } else {
                                resultMsg = false;
                            }

                        }


                    }

                }


                if (arrayAndazeTolha[makanSath[i]] === 300) {

                    if (anbarKeshabi300 >= 4) {
                        anbarKeshabi300 = anbarKeshabi300 - 4;

                    } else {
                        resultMsg = false;
                    }

                }
                else if (arrayAndazeTolha[makanSath[i]] === 250) {
                    if (anbarKeshabi250 >= 4) {
                        anbarKeshabi250 = anbarKeshabi250 - 4;


                    } else {
                        resultMsg = false;
                    }

                }
                else if (arrayAndazeTolha[makanSath[i]] === 130) {
                    if (anbarKeshabi130 >= 4) {
                        anbarKeshabi130 = anbarKeshabi130 - 4;

                    } else {
                        resultMsg = false;
                    }

                }
                else if (arrayAndazeTolha[makanSath[i]] === 100) {
                    if (anbarKeshabi100 >= 4) {
                        anbarKeshabi100 = anbarKeshabi100 - 4;


                    } else {
                        resultMsg = false;
                    }

                }
                else if (arrayAndazeTolha[makanSath[i]] === 75) {
                    if (anbarKeshabi75 >= 4) {
                        anbarKeshabi75 = anbarKeshabi75 - 4;


                    } else {
                        resultMsg = false;
                    }

                }


            }
            if (halatSD1[i] === 4) {

                for (j = 0; j < faseleDRCH.length; j++) {

                    if (j === 0) {
                        if (faseleDRCH[j] === 300) {
                            if (anbarKeshabi300 >= 2) {
                                anbarKeshabi300 = anbarKeshabi300 - 2;
                            }
                            else {
                                resultMsg = false;
                            }


                            for (gh = 0; gh < arrayAndazeTolha.length; gh++) {

                                if (arrayAndazeTolha[gh] === 300) {

                                    if (anbarPlayt300 >= 9) {
                                        anbarPlayt300 = anbarPlayt300 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[gh] === 250) {
                                    if (anbarPlayt250 >= 9) {
                                        anbarPlayt250 = anbarPlayt250 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 130) {
                                    if (anbarPlayt130 >= 9) {
                                        anbarPlayt130 = anbarPlayt130 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 100) {
                                    if (anbarPlayt100 >= 9) {
                                        anbarPlayt100 = anbarPlayt100 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 75) {
                                    if (anbarPlayt75 >= 9) {
                                        anbarPlayt75 = anbarPlayt75 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }


                            }


                        }
                        else if (faseleDRCH[j] === 250) {
                            if (anbarKeshabi250 >= 2) {
                                anbarKeshabi250 = anbarKeshabi250 - 2;


                            } else {
                                resultMsg = false;
                            }


                            for (gh = 0; gh < arrayAndazeTolha.length; gh++) {
                                if (arrayAndazeTolha[gh] === 300) {

                                    if (anbarPlayt300 >= 7) {
                                        anbarPlayt300 = anbarPlayt300 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[gh] === 250) {
                                    if (anbarPlayt250 >= 7) {
                                        anbarPlayt250 = anbarPlayt250 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 130) {
                                    if (anbarPlayt130 >= 7) {
                                        anbarPlayt130 = anbarPlayt130 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 100) {
                                    if (anbarPlayt100 >= 7) {
                                        anbarPlayt100 = anbarPlayt100 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 75) {
                                    if (anbarPlayt75 >= 7) {
                                        anbarPlayt75 = anbarPlayt75 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                            }

                        }
                        else if (faseleDRCH[j] === 130) {
                            if (anbarKeshabi130 >= 2) {
                                anbarKeshabi130 = anbarKeshabi130 - 2;
                            } else {
                                resultMsg = false;
                            }

                            for (gh = 0; gh < arrayAndazeTolha.length; gh++) {

                                if (arrayAndazeTolha[gh] === 300) {

                                    if (anbarPlayt300 >= 4) {
                                        anbarPlayt300 = anbarPlayt300 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[gh] === 250) {
                                    if (anbarPlayt250 >= 4) {
                                        anbarPlayt250 = anbarPlayt250 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 130) {
                                    if (anbarPlayt130 >= 4) {
                                        anbarPlayt130 = anbarPlayt130 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 100) {
                                    if (anbarPlayt100 >= 4) {
                                        anbarPlayt100 = anbarPlayt100 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 45) {
                                    if (anbarPlayt75 >= 4) {
                                        anbarPlayt75 = anbarPlayt75 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                            }

                        }
                        else if (faseleDRCH[j] === 100) {
                            if (anbarKeshabi100 >= 2) {
                                anbarKeshabi100 = anbarKeshabi100 - 2;
                            } else {
                                resultMsg = false;
                            }

                            for (gh = 0; gh < arrayAndazeTolha.length; gh++) {

                                if (arrayAndazeTolha[gh] === 300) {

                                    if (anbarPlayt300 >= 3) {
                                        anbarPlayt300 = anbarPlayt300 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[gh] === 250) {
                                    if (anbarPlayt250 >= 3) {
                                        anbarPlayt250 = anbarPlayt250 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 130) {
                                    if (anbarPlayt130 >= 3) {
                                        anbarPlayt130 = anbarPlayt130 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 100) {
                                    if (anbarPlayt100 >= 3) {
                                        anbarPlayt100 = anbarPlayt100 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 75) {
                                    if (anbarPlayt75 >= 3) {
                                        anbarPlayt75 = anbarPlayt75 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                            }

                        }
                        else if (faseleDRCH[j] === 75) {
                            if (anbarKeshabi75 >= 2) {
                                anbarKeshabi75 = anbarKeshabi75 - 2;


                            } else {
                                resultMsg = false;
                            }

                            for (gh = 0; gh < arrayAndazeTolha.length; gh++) {

                                if (arrayAndazeTolha[gh] === 300) {

                                    if (anbarPlayt300 >= 2) {
                                        anbarPlayt300 = anbarPlayt300 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[gh] === 250) {
                                    if (anbarPlayt250 >= 2) {
                                        anbarPlayt250 = anbarPlayt250 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 130) {
                                    if (anbarPlayt130 >= 2) {
                                        anbarPlayt130 = anbarPlayt130 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 100) {
                                    if (anbarPlayt100 >= 2) {
                                        anbarPlayt100 = anbarPlayt100 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 75) {
                                    if (anbarPlayt75 >= 2) {
                                        anbarPlayt75 = anbarPlayt75 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                            }
                        }
                    }
                    else {

                        if (faseleDRCH[j] === 300) {
                            if (anbarKeshabi300 >= 4) {
                                anbarKeshabi300 = anbarKeshabi300 - 4;
                            }
                            else {
                                resultMsg = false;
                            }
                            for (gh = 0; gh < arrayAndazeTolha.length; gh++) {

                                if (arrayAndazeTolha[gh] === 300) {

                                    if (anbarPlayt300 >= 9) {
                                        anbarPlayt300 = anbarPlayt300 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[gh] === 250) {
                                    if (anbarPlayt250 >= 9) {
                                        anbarPlayt250 = anbarPlayt250 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 130) {
                                    if (anbarPlayt130 >= 9) {
                                        anbarPlayt130 = anbarPlayt130 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 100) {
                                    if (anbarPlayt100 >= 9) {
                                        anbarPlayt100 = anbarPlayt100 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 75) {
                                    if (anbarPlayt75 >= 9) {
                                        anbarPlayt75 = anbarPlayt75 - 9;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }


                            }


                        }
                        else if (faseleDRCH[j] === 250) {
                            if (anbarKeshabi250 >= 4) {
                                anbarKeshabi250 = anbarKeshabi250 - 4;


                            } else {
                                resultMsg = false;
                            }

                            for (gh = 0; gh < arrayAndazeTolha.length; gh++) {
                                if (arrayAndazeTolha[gh] === 300) {

                                    if (anbarPlayt300 >= 7) {
                                        anbarPlayt300 = anbarPlayt300 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[gh] === 250) {
                                    if (anbarPlayt250 >= 7) {
                                        anbarPlayt250 = anbarPlayt250 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 130) {
                                    if (anbarPlayt130 >= 7) {
                                        anbarPlayt130 = anbarPlayt130 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 100) {
                                    if (anbarPlayt100 >= 7) {
                                        anbarPlayt100 = anbarPlayt100 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 75) {
                                    if (anbarPlayt75 >= 7) {
                                        anbarPlayt75 = anbarPlayt75 - 7;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                            }

                        }
                        else if (faseleDRCH[j] === 130) {
                            if (anbarKeshabi130 >= 4) {
                                anbarKeshabi130 = anbarKeshabi130 - 4;
                            } else {
                                resultMsg = false;
                            }
                            for (gh = 0; gh < arrayAndazeTolha.length; gh++) {

                                if (arrayAndazeTolha[gh] === 300) {

                                    if (anbarPlayt300 >= 4) {
                                        anbarPlayt300 = anbarPlayt300 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[gh] === 250) {
                                    if (anbarPlayt250 >= 4) {
                                        anbarPlayt250 = anbarPlayt250 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 130) {
                                    if (anbarPlayt130 >= 4) {
                                        anbarPlayt130 = anbarPlayt130 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 100) {
                                    if (anbarPlayt100 >= 4) {
                                        anbarPlayt100 = anbarPlayt100 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 45) {
                                    if (anbarPlayt75 >= 4) {
                                        anbarPlayt75 = anbarPlayt75 - 4;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                            }

                        }
                        else if (faseleDRCH[j] === 100) {
                            if (anbarKeshabi100 >= 4) {
                                anbarKeshabi100 = anbarKeshabi100 - 4;
                            } else {
                                resultMsg = false;
                            }
                            for (gh = 0; gh < arrayAndazeTolha.length; gh++) {

                                if (arrayAndazeTolha[gh] === 300) {

                                    if (anbarPlayt300 >= 3) {
                                        anbarPlayt300 = anbarPlayt300 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[gh] === 250) {
                                    if (anbarPlayt250 >= 3) {
                                        anbarPlayt250 = anbarPlayt250 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 130) {
                                    if (anbarPlayt130 >= 3) {
                                        anbarPlayt130 = anbarPlayt130 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 100) {
                                    if (anbarPlayt100 >= 3) {
                                        anbarPlayt100 = anbarPlayt100 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 75) {
                                    if (anbarPlayt75 >= 3) {
                                        anbarPlayt75 = anbarPlayt75 - 3;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                            }

                        }
                        else if (faseleDRCH[j] === 75) {
                            if (anbarKeshabi75 >= 4) {
                                anbarKeshabi75 = anbarKeshabi75 - 4;


                            } else {
                                resultMsg = false;
                            }
                            for (gh = 0; gh < arrayAndazeTolha.length; gh++) {

                                if (arrayAndazeTolha[gh] === 300) {

                                    if (anbarPlayt300 >= 2) {
                                        anbarPlayt300 = anbarPlayt300 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }
                                }
                                else if (arrayAndazeTolha[gh] === 250) {
                                    if (anbarPlayt250 >= 2) {
                                        anbarPlayt250 = anbarPlayt250 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 130) {
                                    if (anbarPlayt130 >= 2) {
                                        anbarPlayt130 = anbarPlayt130 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 100) {
                                    if (anbarPlayt100 >= 2) {
                                        anbarPlayt100 = anbarPlayt100 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                                else if (arrayAndazeTolha[gh] === 75) {
                                    if (anbarPlayt75 >= 2) {
                                        anbarPlayt75 = anbarPlayt75 - 2;
                                    }
                                    else {
                                        resultMsg = false;
                                    }

                                }
                            }
                        }
                    }


                }


                for (gh = 0; gh < arrayAndazeTolha.length; gh++) {
                    if (arrayAndazeTolha[gh] === 300) {
                        if (anbarKeshabi300 >= 4) {
                            anbarKeshabi300 = anbarKeshabi300 - 4;

                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[gh] === 250) {
                        if (anbarKeshabi250 >= 4) {
                            anbarKeshabi250 = anbarKeshabi250 - 4;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[gh] === 130) {
                        if (anbarKeshabi130 >= 4) {
                            anbarKeshabi130 = anbarKeshabi130 - 4;

                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[gh] === 100) {
                        if (anbarKeshabi100 >= 4) {
                            anbarKeshabi100 = anbarKeshabi100 - 4;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[gh] === 75) {
                        if (anbarKeshabi75 >= 4) {
                            anbarKeshabi75 = anbarKeshabi75 - 4;


                        } else {
                            resultMsg = false;
                        }

                    }

                }
            }


        }
        var finalSDHeight = 0;


        for (j = 0; j < tedaKolSatheDastresi; j++) {


            if (heightMSD1[j] === undefined) {

                if (finalSDHeight < heightMSD1) {
                    finalSDHeight = heightMSD1;

                }


            } else {

                if (finalSDHeight < heightMSD1[j]) {
                    finalSDHeight = heightMSD1[j];

                }
            }


        }


        finalSDHeight = parseInt((finalSDHeight * 100) / 200);

        for (y = 0; y <= finalSDHeight; y++) {

            if (y === finalSDHeight - 1) {
                if (faseleDRCH[0] === 300) {

                    if (anbarKeshabi300 >= 2) {

                        anbarKeshabi300 = anbarKeshabi300 - 4;

                    } else {
                        resultMsg = false;
                    }
                    if (arrayAndazeTolha[0] === 300) {

                        if (anbarKeshabi300 >= 4) {

                            anbarKeshabi300 = anbarKeshabi300 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt300 >= 8) {
                            anbarPlayt300 = anbarPlayt300 - 8;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }


                    }
                    else if (arrayAndazeTolha[0] === 250) {

                        if (anbarKeshabi250 > 4) {

                            anbarKeshabi250 = anbarKeshabi250 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt250 > 8) {
                            anbarPlayt250 = anbarPlayt250 - 8;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 130) {

                        if (anbarKeshabi130 > 4) {

                            anbarKeshabi130 = anbarKeshabi130 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt130 > 8) {
                            anbarPlayt130 = anbarPlayt130 - 8;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 100) {

                        if (anbarKeshabi100 > 4) {

                            anbarKeshabi100 = anbarKeshabi100 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt100 > 8) {
                            anbarPlayt100 = anbarPlayt100 - 8;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 75) {

                        if (anbarKeshabi75 > 4) {

                            anbarKeshabi75 = anbarKeshabi75 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt75 > 8) {
                            anbarPlayt75 = anbarPlayt75 - 8;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }


                }
                else if (faseleDRCH[0] === 250) {

                    if (anbarKeshabi250 >= 2) {

                        anbarKeshabi250 = anbarKeshabi250 - 4;

                    } else {
                        resultMsg = false;
                    }
                    if (arrayAndazeTolha[0] === 300) {

                        if (anbarKeshabi300 >= 4) {

                            anbarKeshabi300 = anbarKeshabi300 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt300 >= 6) {
                            anbarPlayt300 = anbarPlayt300 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }


                    }
                    else if (arrayAndazeTolha[0] === 250) {

                        if (anbarKeshabi250 > 4) {

                            anbarKeshabi250 = anbarKeshabi250 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt250 > 6) {
                            anbarPlayt250 = anbarPlayt250 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 130) {

                        if (anbarKeshabi130 > 4) {

                            anbarKeshabi130 = anbarKeshabi130 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt130 > 6) {
                            anbarPlayt130 = anbarPlayt130 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 100) {

                        if (anbarKeshabi100 > 4) {

                            anbarKeshabi100 = anbarKeshabi100 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt100 > 6) {
                            anbarPlayt100 = anbarPlayt100 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 75) {

                        if (anbarKeshabi75 > 4) {

                            anbarKeshabi75 = anbarKeshabi75 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt75 > 6) {
                            anbarPlayt75 = anbarPlayt75 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }


                }
                else if (faseleDRCH[0] === 130) {

                    if (anbarKeshabi130 >= 2) {

                        anbarKeshabi130 = anbarKeshabi130 - 4;

                    } else {
                        resultMsg = false;
                    }
                    if (arrayAndazeTolha[0] === 300) {

                        if (anbarKeshabi300 >= 4) {

                            anbarKeshabi300 = anbarKeshabi300 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt300 >= 3) {
                            anbarPlayt300 = anbarPlayt300 - 3;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }


                    }
                    else if (arrayAndazeTolha[0] === 250) {

                        if (anbarKeshabi250 > 4) {

                            anbarKeshabi250 = anbarKeshabi250 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt250 > 6) {
                            anbarPlayt250 = anbarPlayt250 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 130) {

                        if (anbarKeshabi130 > 4) {

                            anbarKeshabi130 = anbarKeshabi130 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt130 > 6) {
                            anbarPlayt130 = anbarPlayt130 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 100) {

                        if (anbarKeshabi100 > 4) {

                            anbarKeshabi100 = anbarKeshabi100 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt100 > 6) {
                            anbarPlayt100 = anbarPlayt100 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 75) {

                        if (anbarKeshabi75 > 4) {

                            anbarKeshabi75 = anbarKeshabi75 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt75 > 6) {
                            anbarPlayt75 = anbarPlayt75 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }


                }
                else if (faseleDRCH[0] === 100) {

                    if (anbarKeshabi100 >= 2) {

                        anbarKeshabi100 = anbarKeshabi100 - 4;

                    } else {
                        resultMsg = false;
                    }
                    if (arrayAndazeTolha[0] === 300) {

                        if (anbarKeshabi300 >= 4) {

                            anbarKeshabi300 = anbarKeshabi300 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt300 >= 2) {
                            anbarPlayt300 = anbarPlayt300 - 2;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }


                    }
                    else if (arrayAndazeTolha[0] === 250) {

                        if (anbarKeshabi250 > 4) {

                            anbarKeshabi250 = anbarKeshabi250 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt250 > 6) {
                            anbarPlayt250 = anbarPlayt250 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 130) {

                        if (anbarKeshabi130 > 4) {

                            anbarKeshabi130 = anbarKeshabi130 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt130 > 6) {
                            anbarPlayt130 = anbarPlayt130 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 100) {

                        if (anbarKeshabi100 > 4) {

                            anbarKeshabi100 = anbarKeshabi100 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt100 > 6) {
                            anbarPlayt100 = anbarPlayt100 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 75) {

                        if (anbarKeshabi75 > 4) {

                            anbarKeshabi75 = anbarKeshabi75 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt75 > 6) {
                            anbarPlayt75 = anbarPlayt75 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }


                }
                else if (faseleDRCH[0] === 75) {

                    if (anbarKeshabi75 >= 2) {

                        anbarKeshabi75 = anbarKeshabi75 - 4;

                    } else {
                        resultMsg = false;
                    }
                    if (arrayAndazeTolha[0] === 300) {

                        if (anbarKeshabi300 >= 4) {

                            anbarKeshabi300 = anbarKeshabi300 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt300 >= 1) {
                            anbarPlayt300 = anbarPlayt300 - 1;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }


                    }
                    else if (arrayAndazeTolha[0] === 250) {

                        if (anbarKeshabi250 > 4) {

                            anbarKeshabi250 = anbarKeshabi250 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt250 > 6) {
                            anbarPlayt250 = anbarPlayt250 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 130) {

                        if (anbarKeshabi130 > 4) {

                            anbarKeshabi130 = anbarKeshabi130 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt130 > 6) {
                            anbarPlayt130 = anbarPlayt130 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 100) {

                        if (anbarKeshabi100 > 4) {

                            anbarKeshabi100 = anbarKeshabi100 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt100 > 6) {
                            anbarPlayt100 = anbarPlayt100 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 75) {

                        if (anbarKeshabi75 > 4) {

                            anbarKeshabi75 = anbarKeshabi75 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt75 > 6) {
                            anbarPlayt75 = anbarPlayt75 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }


                }
            }

            else {
                if (faseleDRCH[0] === 300) {

                    if (anbarKeshabi300 >= 4) {

                        anbarKeshabi300 = anbarKeshabi300 - 4;

                    }
                    else {
                        resultMsg = false;
                    }
                    if (arrayAndazeTolha[0] === 300) {

                        if (anbarKeshabi300 >= 4) {

                            anbarKeshabi300 = anbarKeshabi300 - 4;

                        }
                        else {
                            resultMsg = false;
                        }
                        if (anbarPlayt300 >= 8) {
                            anbarPlayt300 = anbarPlayt300 - 8;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }


                    }
                    else if (arrayAndazeTolha[0] === 250) {

                        if (anbarKeshabi250 > 4) {

                            anbarKeshabi250 = anbarKeshabi250 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt250 > 8) {
                            anbarPlayt250 = anbarPlayt250 - 8;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 130) {

                        if (anbarKeshabi130 > 4) {

                            anbarKeshabi130 = anbarKeshabi130 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt130 > 8) {
                            anbarPlayt130 = anbarPlayt130 - 8;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 100) {

                        if (anbarKeshabi100 > 4) {

                            anbarKeshabi100 = anbarKeshabi100 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt100 > 8) {
                            anbarPlayt100 = anbarPlayt100 - 8;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 75) {

                        if (anbarKeshabi75 >= 4) {

                            anbarKeshabi75 = anbarKeshabi75 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt75 >= 8) {
                            anbarPlayt75 = anbarPlayt75 - 8;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }


                }
                else if (faseleDRCH[0] === 250) {

                    if (anbarKeshabi250 >= 4) {

                        anbarKeshabi250 = anbarKeshabi250 - 4;

                    } else {
                        resultMsg = false;
                    }
                    if (arrayAndazeTolha[0] === 300) {

                        if (anbarKeshabi300 >= 4) {

                            anbarKeshabi300 = anbarKeshabi300 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt300 >= 6) {
                            anbarPlayt300 = anbarPlayt300 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }


                    }
                    else if (arrayAndazeTolha[0] === 250) {

                        if (anbarKeshabi250 > 4) {

                            anbarKeshabi250 = anbarKeshabi250 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt250 > 6) {
                            anbarPlayt250 = anbarPlayt250 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 130) {

                        if (anbarKeshabi130 > 4) {

                            anbarKeshabi130 = anbarKeshabi130 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt130 > 6) {
                            anbarPlayt130 = anbarPlayt130 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 100) {

                        if (anbarKeshabi100 > 4) {

                            anbarKeshabi100 = anbarKeshabi100 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt100 > 6) {
                            anbarPlayt100 = anbarPlayt100 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 75) {

                        if (anbarKeshabi75 > 4) {

                            anbarKeshabi75 = anbarKeshabi75 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt75 > 6) {
                            anbarPlayt75 = anbarPlayt75 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }


                }
                else if (faseleDRCH[0] === 130) {

                    if (anbarKeshabi130 >= 4) {

                        anbarKeshabi130 = anbarKeshabi130 - 4;

                    } else {
                        resultMsg = false;
                    }
                    if (arrayAndazeTolha[0] === 300) {

                        if (anbarKeshabi300 >= 4) {

                            anbarKeshabi300 = anbarKeshabi300 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt300 >= 3) {
                            anbarPlayt300 = anbarPlayt300 - 3;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }


                    }
                    else if (arrayAndazeTolha[0] === 250) {

                        if (anbarKeshabi250 > 4) {

                            anbarKeshabi250 = anbarKeshabi250 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt250 > 6) {
                            anbarPlayt250 = anbarPlayt250 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 130) {

                        if (anbarKeshabi130 > 4) {

                            anbarKeshabi130 = anbarKeshabi130 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt130 > 6) {
                            anbarPlayt130 = anbarPlayt130 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 100) {

                        if (anbarKeshabi100 > 4) {

                            anbarKeshabi100 = anbarKeshabi100 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt100 > 6) {
                            anbarPlayt100 = anbarPlayt100 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 75) {

                        if (anbarKeshabi75 > 4) {

                            anbarKeshabi75 = anbarKeshabi75 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt75 > 6) {
                            anbarPlayt75 = anbarPlayt75 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }


                }
                else if (faseleDRCH[0] === 100) {

                    if (anbarKeshabi100 >= 4) {

                        anbarKeshabi100 = anbarKeshabi100 - 4;

                    } else {
                        resultMsg = false;
                    }
                    if (arrayAndazeTolha[0] === 300) {

                        if (anbarKeshabi300 >= 4) {

                            anbarKeshabi300 = anbarKeshabi300 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt300 >= 2) {
                            anbarPlayt300 = anbarPlayt300 - 2;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }


                    }
                    else if (arrayAndazeTolha[0] === 250) {

                        if (anbarKeshabi250 > 4) {

                            anbarKeshabi250 = anbarKeshabi250 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt250 > 6) {
                            anbarPlayt250 = anbarPlayt250 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 130) {

                        if (anbarKeshabi130 > 4) {

                            anbarKeshabi130 = anbarKeshabi130 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt130 > 6) {
                            anbarPlayt130 = anbarPlayt130 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 100) {

                        if (anbarKeshabi100 > 4) {

                            anbarKeshabi100 = anbarKeshabi100 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt100 > 6) {
                            anbarPlayt100 = anbarPlayt100 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 75) {

                        if (anbarKeshabi75 > 4) {

                            anbarKeshabi75 = anbarKeshabi75 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt75 > 6) {
                            anbarPlayt75 = anbarPlayt75 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }


                }
                else if (faseleDRCH[0] === 75) {

                    if (anbarKeshabi75 >= 4) {

                        anbarKeshabi75 = anbarKeshabi75 - 4;

                    } else {
                        resultMsg = false;
                    }
                    if (arrayAndazeTolha[0] === 300) {

                        if (anbarKeshabi300 >= 4) {

                            anbarKeshabi300 = anbarKeshabi300 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt300 >= 1) {
                            anbarPlayt300 = anbarPlayt300 - 1;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }


                    }
                    else if (arrayAndazeTolha[0] === 250) {

                        if (anbarKeshabi250 > 4) {

                            anbarKeshabi250 = anbarKeshabi250 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt250 > 6) {
                            anbarPlayt250 = anbarPlayt250 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 130) {

                        if (anbarKeshabi130 > 4) {

                            anbarKeshabi130 = anbarKeshabi130 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt130 > 6) {
                            anbarPlayt130 = anbarPlayt130 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 100) {

                        if (anbarKeshabi100 > 4) {

                            anbarKeshabi100 = anbarKeshabi100 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt100 > 6) {
                            anbarPlayt100 = anbarPlayt100 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }
                    else if (arrayAndazeTolha[0] === 75) {

                        if (anbarKeshabi75 > 4) {

                            anbarKeshabi75 = anbarKeshabi75 - 4;

                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlayt75 > 6) {
                            anbarPlayt75 = anbarPlayt75 - 6;


                        } else {
                            resultMsg = false;
                        }
                        if (anbarPlaytPeleDarD >= 1) {
                            anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                        } else {
                            resultMsg = false;
                        }

                    }


                }
            }

        }


    }

    if (resultMsg == false) {
        alert(NNo);
    }


    var keshabi_075 = (anbarKeshabi75R - anbarKeshabi75);
    var keshabi_1 = (anbarKeshabi100R - anbarKeshabi100);
    var keshabi_13 = (anbarKeshabi130R - anbarKeshabi130);
    var keshabi_25 = (anbarKeshabi250R - anbarKeshabi250);
    var keshabi_3 = (anbarKeshabi300R - anbarKeshabi300);

    var plate_075 = (anbarPlayt75R - anbarPlayt75);
    var plate_1 = (anbarPlayt100R - anbarPlayt100);
    var plate_13 = (anbarPlayt130R - anbarPlayt130);
    var plate_25 = (anbarPlayt250R - anbarPlayt250);
    var plate_3 = (anbarPlayt300R - anbarPlayt300);

    var gheyghi_25 = (anbarGHechi250R - anbarGHechi250);
    var gheyghi_3 = (anbarGHechi300R - anbarGHechi300);

    var base_05 = (anbarPaye50R - anbarPaye50);
    var base_1 = (anbarPaye100R - anbarPaye100);
    var base_2 = (anbarPaye200R - anbarPaye200);
    var base_3 = (anbarPaye300R - anbarPaye300);
    var base_4 = (anbarPaye400R - anbarPaye400);
    
    var platepeledar = (anbarPlaytPeleDarDR - anbarPlaytPeleDarD);


    return [["تعداد کشابی 0.75", keshabi_075],
        ["تعداد کشابی 1 متر", keshabi_1],
        ["تعداد کشابی 1.3 متر", keshabi_13],
        ["تعداد کشابی 2.5 متر", keshabi_25],
        ["تعداد کشابی 3 متر", keshabi_3],

        ["تعداد پلیت 0.75", plate_075],
        ["تعداد پلیت 1 متر", plate_1],
        ["تعداد پلیت 1.3 متر", plate_13],
        ["تعداد پلیت 2,5 متر", plate_25],
        ["تعداد پلیت 3 متر", plate_3],

        ["تعداد قیچی 2.5 متر", gheyghi_25],
        ["تعداد قیچی 3 متر", gheyghi_3],

        ["تعداد پایه 0.5 متر", base_05],
        ["تعداد پایه 1 متر", base_1],
        ["تعداد پایه 2 متر", base_2],
        ["تعداد پایه 3 متر", base_3],
        ["تعداد پایه 4 متر", base_4],

        ["تعداد پله", platepeledar]];

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










