// function SingleWall(xirx, yiry, faseleDRCH, heightMSD1, widthMSD1, halatSD1,tedaKolSatheDastresi, pipeStock, anbarPaye,anbarGHechi) {
function CageSys(widthMO, heightMO,
    faseleD, anbarKeshabi,
    anbarPaye, anbarGHechi, anbarPlayt, anbarPlaytPeleDar) {
    alert("پیغام 2");
    var faseleDRCH = [];


    for (d = faseleD; d > 0;) {
        if (d === 200) {
            faseleDRCH.push(200)
            d = d - 200;

        }
        else if (d === 100) {
            faseleDRCH.push(100)
            d = d - 100;

        } else {
            faseleDRCH.push(300)
            d = d - 300;

        }
    }

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


    var resultMsg = true;


    var finalAlert = "موجودی کافی نیست";


    var widthM = widthMO;
    var heightM = heightMO;


    var widthC = (widthM * 100);
    var heightC = (heightM * 100);


    var tedadErtefa = parseInt(heightC / 200);

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
                        resultMsg = false


                    }
                }

                else {
                    resultMsg = false


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
                        resultMsg = false


                    }
                }

                else {
                    resultMsg = false


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
                    resultMsg = false


                }
            }

            else {
                resultMsg = false


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
                resultMsg = false


            }
        }
        else {

            if (anbarKeshabi300 >= (faseleDRCH.length + 1) * (tedadErtefa + 1)) {
                anbarKeshabi300 = anbarKeshabi300 - (faseleDRCH.length + 1) * (tedadErtefa + 1);
                j = j - 300;

                finalLoopTol = finalLoopTol + 1

                arrayAndazeTolha.push(300);


            }
            else if (anbarKeshabi250 >= (faseleDRCH.length + 1) * (tedadErtefa + 1)) {
                anbarKeshabi250 = anbarKeshabi250 - (faseleDRCH.length + 1) * (tedadErtefa + 1);
                j = j - 250;

                finalLoopTol = finalLoopTol + 1
                arrayAndazeTolha.push(250);


            }
            else if (anbarKeshabi130 >= (faseleDRCH.length + 1) * (tedadErtefa + 1)) {
                anbarKeshabi130 = anbarKeshabi130 - (faseleDRCH.length + 1) * (tedadErtefa + 1);
                j = j - 130;

                finalLoopTol = finalLoopTol + 1
                arrayAndazeTolha.push(130);


            }
            else if (anbarKeshabi100 >= (faseleDRCH.length + 1) * (tedadErtefa + 1)) {
                anbarKeshabi100 = anbarKeshabi100 - (faseleDRCH.length + 1) * (tedadErtefa + 1);
                j = j - 100;

                finalLoopTol = finalLoopTol + 1
                arrayAndazeTolha.push(100);

            }
            else if (anbarKeshabi75 >= (faseleDRCH.length + 1) * (tedadErtefa + 1)) {
                anbarKeshabi75 = anbarKeshabi75 - (faseleDRCH.length + 1) * (tedadErtefa + 1);
                j = j - 75;

                finalLoopTol = finalLoopTol + 1
                arrayAndazeTolha.push(75);


            }
            else {
                resultMsg = false
            }
        }

    }


    // hesab brase tol
    for (i = 0; i < 2; i++) {

        for (i = 0; i < finalLoopTol - 1; i = i + 3) {


            if (arrayAndazeTolha[i] === 300) {
                if (anbarGHechi300 > tedadErtefa) {
                    anbarGHechi300 = anbarGHechi300 - tedadErtefa;


                } else {
                    resultMsg = false
                }

            }
            else if (arrayAndazeTolha[i] === 250) {
                if (anbarGHechi300 > tedadErtefa) {
                    anbarGHechi300 = anbarGHechi300 - tedadErtefa;


                } else {
                    resultMsg = false
                }

            }
            else if (arrayAndazeTolha[i] === 130) {
                if (anbarGHechi250 > tedadErtefa) {
                    anbarGHechi250 = anbarGHechi250 - tedadErtefa;


                } else {
                    resultMsg = false
                }

            }
            else if (arrayAndazeTolha[i] === 100) {

                if (anbarGHechi250 > tedadErtefa) {
                    anbarGHechi250 = anbarGHechi250 - tedadErtefa;


                } else {
                    resultMsg = false
                }
            }
            else if (arrayAndazeTolha[i] === 75) {

                var tedad75T = parseInt(heightC / 250);

                if (anbarGHechi250 > tedad75T) {
                    anbarGHechi250 = anbarGHechi250 - tedad75T;

                } else {
                    resultMsg = false
                }


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
                    resultMsg = false
                }

            }
            else if (faseleDRCH[i] === 250) {
                if (anbarGHechi300 > tedadErtefa) {
                    anbarGHechi300 = anbarGHechi300 - tedadErtefa;


                } else {
                    resultMsg = false
                }

            }
            else if (faseleDRCH[i] === 130) {
                if (anbarGHechi250 > tedadErtefa) {
                    anbarGHechi250 = anbarGHechi250 - tedadErtefa;


                } else {
                    resultMsg = false
                }

            }
            else if (faseleDRCH[i] === 100) {

                if (anbarGHechi250 > tedadErtefa) {
                    anbarGHechi250 = anbarGHechi250 - tedadErtefa;


                } else {
                    resultMsg = false
                }
            }
            else if (faseleDRCH[i] === 75) {
                var tedad75T = parseInt(heightC / 250);

                if (anbarGHechi250 > tedad75T) {
                    anbarGHechi250 = anbarGHechi250 - tedad75T;

                } else {
                    resultMsg = false
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
    }


    // hesab kardan arz
    for (ij = 0; ij < faseleDRCH.length; ij++) {
        for (j = 0; j <= finalLoopTol; j++) {

            for (i = 0; i <= tedadErtefa; i++) {

                if (faseleDRCH[ij] === 75) {
                    anbarKeshabi75 = anbarKeshabi75 - 1;


                }
                else if (faseleDRCH[ij] === 100) {
                    anbarKeshabi100 = anbarKeshabi100 - 1;


                } else if (faseleDRCH[ij] === 130) {
                    anbarKeshabi130 = anbarKeshabi130 - 1;


                } else if (faseleDRCH[ij] === 250) {
                    anbarKeshabi250 = anbarKeshab250 - 1;


                } else if (faseleDRCH[ij] === 300) {
                    anbarKeshabi300 = anbarKeshabi300 - 1;


                } else {
                    resultMsg = false


                }


            }

        }
    }


    //    hesab sathe dastresi
    var ASD = true;
    if (ASD === true) {


        for (i = 0; i < faseleDRCH.length; i++) {
            if (faseleDRCH[i] === 75) {
                if (anbarKeshabi75 > 4) {
                    anbarKeshabi75 = anbarKeshabi75 - 4;
                } else {
                    resultMsg = false


                }


            }
            else if (faseleDRCH[i] === 100) {
                if (anbarKeshabi100 > 4) {
                    anbarKeshabi100 = anbarKeshabi100 - 4;
                } else {
                    resultMsg = false


                }


            }
            else if (faseleDRCH[i] === 130) {
                if (anbarKeshabi130 > 4) {
                    anbarKeshabi130 = anbarKeshabi130 - 4;
                } else {
                    resultMsg = false


                }


            }
            else if (faseleDRCH[i] === 250) {
                if (anbarKeshabi250 > 4) {
                    anbarKeshabi250 = anbarKeshabi250 - 4;
                } else {
                    resultMsg = false


                }


            }
            else if (faseleDRCH[i] === 300) {
                if (anbarKeshabi300 > 4) {
                    anbarKeshabi300 = anbarKeshabi300 - 4;
                } else {
                    resultMsg = false


                }


            }

        }

        for (i = 0; i < arrayAndazeTolha.length; i++) {
            if (arrayAndazeTolha[i] === 75) {
                if (anbarKeshabi75 > 4) {
                    anbarKeshabi75 = anbarKeshabi75 - 4;
                } else {
                    resultMsg = false


                }


            }
            else if (arrayAndazeTolha[i] === 100) {
                if (anbarKeshabi100 > 4) {
                    anbarKeshabi100 = anbarKeshabi100 - 4;
                } else {
                    resultMsg = false


                }


            }
            else if (arrayAndazeTolha[i] === 130) {
                if (anbarKeshabi130 > 4) {
                    anbarKeshabi130 = anbarKeshabi130 - 4;
                } else {
                    resultMsg = false


                }


            }
            else if (arrayAndazeTolha[i] === 250) {
                if (anbarKeshabi250 > 4) {
                    anbarKeshabi250 = anbarKeshabi250 - 4;
                } else {
                    resultMsg = false


                }


            }
            else if (arrayAndazeTolha[i] === 300) {
                if (anbarKeshabi300 > 4) {
                    anbarKeshabi300 = anbarKeshabi300 - 4;
                } else {
                    resultMsg = false


                }


            }

        }


        for (i = 0; i < faseleDRCH.length; i++) {
            for (j = 0; j < arrayAndazeTolha.length; j++) {

                if (faseleDRCH[i] === 75) {
                    if (arrayAndazeTolha[j] === 75) {

                        if (anbarPlayt75 >= 2) {
                            anbarPlayt75 = anbarPlayt75 - 2;

                        } else {
                            resultMsg = false


                        }

                    }
                    else if (arrayAndazeTolha[j] === 100) {

                        if (anbarPlayt100 >= 2) {
                            anbarPlayt100 = anbarPlayt100 - 2;

                        } else {
                            resultMsg = false


                        }

                    }
                    else if (arrayAndazeTolha[j] === 130) {

                        if (anbarPlayt130 >= 2) {
                            anbarPlayt130 = anbarPlayt130 - 2;

                        } else {
                            resultMsg = false


                        }

                    }
                    else if (arrayAndazeTolha[j] === 250) {

                        if (anbarPlayt250 >= 2) {
                            anbarPlayt250 = anbarPlayt250 - 2;

                        } else {
                            resultMsg = false


                        }

                    }
                    else if (arrayAndazeTolha[j] === 300) {

                        if (anbarPlayt300 >= 2) {
                            anbarPlayt300 = anbarPlayt300 - 2;

                        } else {
                            resultMsg = false


                        }

                    }


                }
                else if (faseleDRCH[i] === 100) {
                    if (arrayAndazeTolha[j] === 75) {

                        if (anbarPlayt75 >= 3) {
                            anbarPlayt75 = anbarPlayt75 - 3;

                        } else {
                            resultMsg = false


                        }

                    }
                    else if (arrayAndazeTolha[j] === 100) {

                        if (anbarPlayt100 >= 3) {
                            anbarPlayt100 = anbarPlayt100 - 3;

                        } else {
                            resultMsg = false


                        }

                    }
                    else if (arrayAndazeTolha[j] === 130) {

                        if (anbarPlayt130 >= 3) {
                            anbarPlayt130 = anbarPlayt130 - 3;

                        } else {
                            resultMsg = false


                        }

                    }
                    else if (arrayAndazeTolha[j] === 250) {

                        if (anbarPlayt250 >= 3) {
                            anbarPlayt250 = anbarPlayt250 - 3;

                        } else {
                            resultMsg = false


                        }

                    }
                    else if (arrayAndazeTolha[j] === 300) {

                        if (anbarPlayt300 >= 3) {
                            anbarPlayt300 = anbarPlayt300 - 3;

                        } else {
                            resultMsg = false


                        }

                    }


                }
                else if (faseleDRCH[i] === 130) {
                    if (arrayAndazeTolha[j] === 75) {

                        if (anbarPlayt75 >= 4) {
                            anbarPlayt75 = anbarPlayt75 - 4;

                        } else {
                            resultMsg = false


                        }

                    }
                    else if (arrayAndazeTolha[j] === 100) {

                        if (anbarPlayt100 >= 4) {
                            anbarPlayt100 = anbarPlayt100 - 4;

                        } else {
                            resultMsg = false


                        }

                    }
                    else if (arrayAndazeTolha[j] === 130) {

                        if (anbarPlayt130 >= 4) {
                            anbarPlayt130 = anbarPlayt130 - 4;

                        } else {
                            resultMsg = false


                        }

                    }
                    else if (arrayAndazeTolha[j] === 250) {

                        if (anbarPlayt250 >= 4) {
                            anbarPlayt250 = anbarPlayt250 - 4;

                        } else {
                            resultMsg = false


                        }

                    }
                    else if (arrayAndazeTolha[j] === 300) {

                        if (anbarPlayt300 >= 4) {
                            anbarPlayt300 = anbarPlayt300 - 4;

                        } else {
                            resultMsg = false


                        }

                    }


                }
                else if (faseleDRCH[i] === 250) {
                    if (arrayAndazeTolha[j] === 75) {

                        if (anbarPlayt75 >= 7) {
                            anbarPlayt75 = anbarPlayt75 - 7;

                        } else {
                            resultMsg = false


                        }

                    }
                    else if (arrayAndazeTolha[j] === 100) {

                        if (anbarPlayt100 >= 7) {
                            anbarPlayt100 = anbarPlayt100 - 7;

                        } else {
                            resultMsg = false


                        }

                    }
                    else if (arrayAndazeTolha[j] === 130) {

                        if (anbarPlayt130 >= 7) {
                            anbarPlayt130 = anbarPlayt130 - 7;

                        } else {
                            resultMsg = false


                        }

                    }
                    else if (arrayAndazeTolha[j] === 250) {

                        if (anbarPlayt250 >= 7) {
                            anbarPlayt250 = anbarPlayt250 - 7;

                        } else {
                            resultMsg = false


                        }

                    }
                    else if (arrayAndazeTolha[j] === 300) {

                        if (anbarPlayt300 >= 7) {
                            anbarPlayt300 = anbarPlayt300 - 7;

                        } else {
                            resultMsg = false


                        }

                    }


                }
                else if (faseleDRCH[i] === 300) {
                    if (arrayAndazeTolha[j] === 75) {

                        if (anbarPlayt75 >= 9) {
                            anbarPlayt75 = anbarPlayt75 - 9;

                        } else {
                            resultMsg = false


                        }

                    }
                    else if (arrayAndazeTolha[j] === 100) {

                        if (anbarPlayt100 >= 9) {
                            anbarPlayt100 = anbarPlayt100 - 9;

                        } else {
                            resultMsg = false


                        }

                    }
                    else if (arrayAndazeTolha[j] === 130) {

                        if (anbarPlayt130 >= 9) {
                            anbarPlayt130 = anbarPlayt130 - 9;

                        } else {
                            resultMsg = false


                        }

                    }
                    else if (arrayAndazeTolha[j] === 250) {

                        if (anbarPlayt250 >= 9) {
                            anbarPlayt250 = anbarPlayt250 - 9;

                        } else {
                            resultMsg = false


                        }

                    }
                    else if (arrayAndazeTolha[j] === 300) {

                        if (anbarPlayt300 >= 9) {
                            anbarPlayt300 = anbarPlayt300 - 9;

                        } else {
                            resultMsg = false


                        }

                    }


                }
            }
        }

        if (arrayAndazeTolha[0] === 300) {

            anbarPlayt300 = anbarPlayt300 + 1
        }
        else if (arrayAndazeTolha[0] === 250) {

            anbarPlayt250 = anbarPlayt250 + 1
        }
        else if (arrayAndazeTolha[0] === 130) {

            anbarPlayt130 = anbarPlayt130 + 1
        }
        else if (arrayAndazeTolha[0] === 100) {

            anbarPlayt100 = anbarPlayt100 + 1
        }
        else if (arrayAndazeTolha[0] === 75) {

            anbarPlayt75 = anbarPlayt75 + 1
        }


        var finalSDHeight = 0

        finalSDHeight = parseInt((heightM * 100) / 200);

        for (y = 0; y < finalSDHeight - 1; y++) {
            if (anbarPlaytPeleDarD >= 1) {

                anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;

            } else {
                resultMsg = false
            }


            if (faseleDRCH[0] === 300) {

                if (anbarKeshabi300 >= 4) {

                    anbarKeshabi300 = anbarKeshabi300 - 4;

                } else {
                    resultMsg = false
                }
                if (arrayAndazeTolha[0] === 300) {

                    if (anbarKeshabi300 >= 4) {

                        anbarKeshabi300 = anbarKeshabi300 - 4;

                    } else {
                        resultMsg = false
                    }
                    if (anbarPlayt300 >= 8) {
                        anbarPlayt300 = anbarPlayt300 - 8;


                    } else {
                        resultMsg = false
                    }
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                    } else {
                        resultMsg = false
                    }


                }
                else if (arrayAndazeTolha[0] === 250) {

                    if (anbarKeshabi250 > 4) {

                        anbarKeshabi250 = anbarKeshabi250 - 4;

                    } else {
                        resultMsg = false
                    }
                    if (anbarPlayt250 > 8) {
                        anbarPlayt250 = anbarPlayt250 - 8;


                    } else {
                        resultMsg = false
                    }
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                    } else {
                        resultMsg = false
                    }

                }
                else if (arrayAndazeTolha[0] === 130) {

                    if (anbarKeshabi130 > 4) {

                        anbarKeshabi130 = anbarKeshabi130 - 4;

                    } else {
                        resultMsg = false
                    }
                    if (anbarPlayt130 > 8) {
                        anbarPlayt130 = anbarPlayt130 - 8;


                    } else {
                        resultMsg = false
                    }
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                    } else {
                        resultMsg = false
                    }

                }
                else if (arrayAndazeTolha[0] === 100) {

                    if (anbarKeshabi100 > 4) {

                        anbarKeshabi100 = anbarKeshabi100 - 4;

                    } else {
                        resultMsg = false
                    }
                    if (anbarPlayt100 > 8) {
                        anbarPlayt100 = anbarPlayt100 - 8;


                    } else {
                        resultMsg = false
                    }
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                    } else {
                        resultMsg = false
                    }

                }
                else if (arrayAndazeTolha[0] === 75) {

                    if (anbarKeshabi75 > 4) {

                        anbarKeshabi75 = anbarKeshabi75 - 4;

                    } else {
                        resultMsg = false
                    }
                    if (anbarPlayt75 > 8) {
                        anbarPlayt75 = anbarPlayt75 - 8;


                    } else {
                        resultMsg = false
                    }
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                    } else {
                        resultMsg = false
                    }

                }


            }
            else if (faseleDRCH[0] === 250) {

                if (anbarKeshabi250 >= 4) {

                    anbarKeshabi250 = anbarKeshabi250 - 4;

                } else {
                    resultMsg = false
                }
                if (arrayAndazeTolha[0] === 300) {

                    if (anbarKeshabi300 >= 4) {

                        anbarKeshabi300 = anbarKeshabi300 - 4;

                    } else {
                        resultMsg = false
                    }
                    if (anbarPlayt300 >= 6) {
                        anbarPlayt300 = anbarPlayt300 - 6;


                    } else {
                        resultMsg = false
                    }
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                    } else {
                        resultMsg = false
                    }


                }
                else if (arrayAndazeTolha[0] === 250) {

                    if (anbarKeshabi250 > 4) {

                        anbarKeshabi250 = anbarKeshabi250 - 4;

                    } else {
                        resultMsg = false
                    }
                    if (anbarPlayt250 > 6) {
                        anbarPlayt250 = anbarPlayt250 - 6;


                    } else {
                        resultMsg = false
                    }
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                    } else {
                        resultMsg = false
                    }

                }
                else if (arrayAndazeTolha[0] === 130) {

                    if (anbarKeshabi130 > 4) {

                        anbarKeshabi130 = anbarKeshabi130 - 4;

                    } else {
                        resultMsg = false
                    }
                    if (anbarPlayt130 > 6) {
                        anbarPlayt130 = anbarPlayt130 - 6;


                    } else {
                        resultMsg = false
                    }
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                    } else {
                        resultMsg = false
                    }

                }
                else if (arrayAndazeTolha[0] === 100) {

                    if (anbarKeshabi100 > 4) {

                        anbarKeshabi100 = anbarKeshabi100 - 4;

                    } else {
                        resultMsg = false
                    }
                    if (anbarPlayt100 > 6) {
                        anbarPlayt100 = anbarPlayt100 - 6;


                    } else {
                        resultMsg = false
                    }
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                    } else {
                        resultMsg = false
                    }

                }
                else if (arrayAndazeTolha[0] === 75) {

                    if (anbarKeshabi75 > 4) {

                        anbarKeshabi75 = anbarKeshabi75 - 4;

                    } else {
                        resultMsg = false
                    }
                    if (anbarPlayt75 > 6) {
                        anbarPlayt75 = anbarPlayt75 - 6;


                    } else {
                        resultMsg = false
                    }
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                    } else {
                        resultMsg = false
                    }

                }


            }
            else if (faseleDRCH[0] === 130) {

                if (anbarKeshabi130 >= 4) {

                    anbarKeshabi130 = anbarKeshabi130 - 4;

                } else {
                    resultMsg = false
                }
                if (arrayAndazeTolha[0] === 300) {

                    if (anbarKeshabi300 >= 4) {

                        anbarKeshabi300 = anbarKeshabi300 - 4;

                    } else {
                        resultMsg = false
                    }
                    if (anbarPlayt300 >= 3) {
                        anbarPlayt300 = anbarPlayt300 - 3;


                    } else {
                        resultMsg = false
                    }
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                    } else {
                        resultMsg = false
                    }


                }
                else if (arrayAndazeTolha[0] === 250) {

                    if (anbarKeshabi250 > 4) {

                        anbarKeshabi250 = anbarKeshabi250 - 4;

                    } else {
                        resultMsg = false
                    }
                    if (anbarPlayt250 > 6) {
                        anbarPlayt250 = anbarPlayt250 - 6;


                    } else {
                        resultMsg = false
                    }
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                    } else {
                        resultMsg = false
                    }

                }
                else if (arrayAndazeTolha[0] === 130) {

                    if (anbarKeshabi130 > 4) {

                        anbarKeshabi130 = anbarKeshabi130 - 4;

                    } else {
                        resultMsg = false
                    }
                    if (anbarPlayt130 > 6) {
                        anbarPlayt130 = anbarPlayt130 - 6;


                    } else {
                        resultMsg = false
                    }
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                    } else {
                        resultMsg = false
                    }

                }
                else if (arrayAndazeTolha[0] === 100) {

                    if (anbarKeshabi100 > 4) {

                        anbarKeshabi100 = anbarKeshabi100 - 4;

                    } else {
                        resultMsg = false
                    }
                    if (anbarPlayt100 > 6) {
                        anbarPlayt100 = anbarPlayt100 - 6;


                    } else {
                        resultMsg = false
                    }
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                    } else {
                        resultMsg = false
                    }

                }
                else if (arrayAndazeTolha[0] === 75) {

                    if (anbarKeshabi75 > 4) {

                        anbarKeshabi75 = anbarKeshabi75 - 4;

                    } else {
                        resultMsg = false
                    }
                    if (anbarPlayt75 > 6) {
                        anbarPlayt75 = anbarPlayt75 - 6;


                    } else {
                        resultMsg = false
                    }
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                    } else {
                        resultMsg = false
                    }

                }


            }
            else if (faseleDRCH[0] === 100) {

                if (anbarKeshabi100 >= 4) {

                    anbarKeshabi100 = anbarKeshabi100 - 4;

                } else {
                    resultMsg = false
                }
                if (arrayAndazeTolha[0] === 300) {

                    if (anbarKeshabi300 >= 4) {

                        anbarKeshabi300 = anbarKeshabi300 - 4;

                    } else {
                        resultMsg = false
                    }
                    if (anbarPlayt300 >= 2) {
                        anbarPlayt300 = anbarPlayt300 - 2;


                    } else {
                        resultMsg = false
                    }
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                    } else {
                        resultMsg = false
                    }


                }
                else if (arrayAndazeTolha[0] === 250) {

                    if (anbarKeshabi250 > 4) {

                        anbarKeshabi250 = anbarKeshabi250 - 4;

                    } else {
                        resultMsg = false
                    }
                    if (anbarPlayt250 > 6) {
                        anbarPlayt250 = anbarPlayt250 - 6;


                    } else {
                        resultMsg = false
                    }
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                    } else {
                        resultMsg = false
                    }

                }
                else if (arrayAndazeTolha[0] === 130) {

                    if (anbarKeshabi130 > 4) {

                        anbarKeshabi130 = anbarKeshabi130 - 4;

                    } else {
                        resultMsg = false
                    }
                    if (anbarPlayt130 > 6) {
                        anbarPlayt130 = anbarPlayt130 - 6;


                    } else {
                        resultMsg = false
                    }
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                    } else {
                        resultMsg = false
                    }

                }
                else if (arrayAndazeTolha[0] === 100) {

                    if (anbarKeshabi100 > 4) {

                        anbarKeshabi100 = anbarKeshabi100 - 4;

                    } else {
                        resultMsg = false
                    }
                    if (anbarPlayt100 > 6) {
                        anbarPlayt100 = anbarPlayt100 - 6;


                    } else {
                        resultMsg = false
                    }
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                    } else {
                        resultMsg = false
                    }

                }
                else if (arrayAndazeTolha[0] === 75) {

                    if (anbarKeshabi75 > 4) {

                        anbarKeshabi75 = anbarKeshabi75 - 4;

                    } else {
                        resultMsg = false
                    }
                    if (anbarPlayt75 > 6) {
                        anbarPlayt75 = anbarPlayt75 - 6;


                    } else {
                        resultMsg = false
                    }
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                    } else {
                        resultMsg = false
                    }

                }


            }
            else if (faseleDRCH[0] === 75) {

                if (anbarKeshabi75 >= 4) {

                    anbarKeshabi75 = anbarKeshabi75 - 4;

                } else {
                    resultMsg = false
                }
                if (arrayAndazeTolha[0] === 300) {

                    if (anbarKeshabi300 >= 4) {

                        anbarKeshabi300 = anbarKeshabi300 - 4;

                    } else {
                        resultMsg = false
                    }
                    if (anbarPlayt300 >= 1) {
                        anbarPlayt300 = anbarPlayt300 - 1;


                    } else {
                        resultMsg = false
                    }
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                    } else {
                        resultMsg = false
                    }


                }
                else if (arrayAndazeTolha[0] === 250) {

                    if (anbarKeshabi250 > 4) {

                        anbarKeshabi250 = anbarKeshabi250 - 4;

                    } else {
                        resultMsg = false
                    }
                    if (anbarPlayt250 > 6) {
                        anbarPlayt250 = anbarPlayt250 - 6;


                    } else {
                        resultMsg = false
                    }
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                    } else {
                        resultMsg = false
                    }

                }
                else if (arrayAndazeTolha[0] === 130) {

                    if (anbarKeshabi130 > 4) {

                        anbarKeshabi130 = anbarKeshabi130 - 4;

                    } else {
                        resultMsg = false
                    }
                    if (anbarPlayt130 > 6) {
                        anbarPlayt130 = anbarPlayt130 - 6;


                    } else {
                        resultMsg = false
                    }
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                    } else {
                        resultMsg = false
                    }

                }
                else if (arrayAndazeTolha[0] === 100) {

                    if (anbarKeshabi100 > 4) {

                        anbarKeshabi100 = anbarKeshabi100 - 4;

                    } else {
                        resultMsg = false
                    }
                    if (anbarPlayt100 > 6) {
                        anbarPlayt100 = anbarPlayt100 - 6;


                    } else {
                        resultMsg = false
                    }
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                    } else {
                        resultMsg = false
                    }

                }
                else if (arrayAndazeTolha[0] === 75) {

                    if (anbarKeshabi75 > 4) {

                        anbarKeshabi75 = anbarKeshabi75 - 4;

                    } else {
                        resultMsg = false
                    }
                    if (anbarPlayt75 > 6) {
                        anbarPlayt75 = anbarPlayt75 - 6;


                    } else {
                        resultMsg = false
                    }
                    if (anbarPlaytPeleDarD >= 1) {
                        anbarPlaytPeleDarD = anbarPlaytPeleDarD - 1;


                    } else {
                        resultMsg = false
                    }

                }


            }


        }
        anbarPlaytPeleDarD = anbarPlaytPeleDarD + 1;

    }
    if (resultMsg == false) {
        alert(finalAlert);
    }
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
    ["تعداد پله", pele]];

    // alert("تعداد کشابی 0.75" + "   " + (anbarKeshabi75R - anbarKeshabi75))
    // alert("تعداد کشابی 1 متر " + "   " + (anbarKeshabi100R - anbarKeshabi100))
    // alert("تعداد کشابی 1.3 متر" + "   " + (anbarKeshabi130R - anbarKeshabi130))
    // alert("تعداد کشابی 2.5 متر" + "   " + (anbarKeshabi250R - anbarKeshabi250))
    // alert("تعداد کشابی 3 متر" + "   " + (anbarKeshabi300R - anbarKeshabi300))

    // alert("تعداد پلیت 0.75" + "   " + (anbarPlayt75R - anbarPlayt75))
    // alert("تعداد پلیت 1 متر " + "   " + (anbarPlayt100R - anbarPlayt100))
    // alert("تعداد پلیت 1.3 متر" + "   " + (anbarPlayt130R - anbarPlayt130))
    // alert("تعداد پلیت 2.5 متر" + "   " + (anbarPlayt250R - anbarPlayt250))
    // alert("تعداد پلیت 3 متر" + "   " + (anbarPlayt300R - anbarPlayt300))

    // alert("تعداد قیچی 2.5 متر" + "   " + (anbarGHechi250R - anbarGHechi250))
    // alert("تعداد قیچی 3 متر" + "   " + (anbarGHechi300R - anbarGHechi300))


    // alert("تعداد پایه 0.5 متر" + "   " + (anbarPaye50R - anbarPaye50))
    // alert("تعداد پایه 1 متر" + "   " + (anbarPaye100R - anbarPaye100))
    // alert("تعداد پایه 2 متر" + "   " + (anbarPaye200R - anbarPaye200))
    // alert("تعداد پایه 3 متر" + "   " + (anbarPaye300R - anbarPaye300))
    // alert("تعداد پایه 4 متر" + "   " + (anbarPaye400R - anbarPaye400))
    // alert("تعداد پله" + "   " + (anbarPlaytPeleDarDR - anbarPlaytPeleDarD))


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










