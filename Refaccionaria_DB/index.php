        
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
        <meta name="description" content="">
        <meta name="author" content="">
        <link rel="icon" href="favicon.ico">

        <title>PHP Customerdb - Dashboard Template for Bootstrap</title>

        <!-- Bootstrap core CSS -->
        <link href="css/bootstrap.min.css" rel="stylesheet">

        <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
        <link href="assets/css/ie10-viewport-bug-workaround.css" rel="stylesheet">

        <!-- Custom styles for this template -->
        <link href="css/dashboard.css" rel="stylesheet">

        <!-- Just for debugging purposes. Don't actually copy these 2 lines! -->
        <!--[if lt IE 9]><script src="../../assets/js/ie8-responsive-file-warning.js"></script><![endif]-->
        <script src="assets/js/ie-emulation-modes-warning.js"></script>

        <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
        <!--[if lt IE 9]>
          <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
          <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
        <![endif]-->
    </head>

    <body>
        

        <nav class="navbar navbar-inverse navbar-fixed-top">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" 
                            data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="#">PHP Customerdb</a>
                </div>
                <div id="navbar" class="navbar-collapse collapse">
                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="#">Dashboard</a></li>             
                        <li><a href="#">Ayuda</a></li>
                        <li><a href="http://www.codigoxules.org" target="blanck">Código Xules</a></li>
                    </ul>
                    <form class="navbar-form navbar-right">
                        <input type="text" class="form-control" placeholder="Search...">
                    </form>
                </div>
            </div>
        </nav>

        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-3 col-md-2 sidebar">
                    <ul class="nav nav-sidebar">
                        <li class="active"><a href="http://localhost/PhpCustomerdb/index.php">Idiomas <span class="sr-only">(current)</span></a></li>
                        <li><a href="">Monedas</a></li>
                        <li><a href="">Países</a></li>          
                    </ul>
                    <ul class="nav nav-sidebar">            
                        <li><a href="">Empresa</a></li>
                        <li><a href="">Clientes</a></li>
                    </ul>
                    <ul class="nav nav-sidebar">            
                        <li><a href="#">Informes</a></li>
                        <li><a href="#">Análisis</a></li>  
                        <li><a href="">Ayuda</a></li>
                    </ul>
                </div>
                <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
                    <h1 class="page-header">Dashboard</h1>

                    <div class="row placeholders">
                        <div class="col-xs-6 col-sm-3 placeholder">
                            <img src="data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" width="150" height="150" class="img-responsive" alt="Generic placeholder thumbnail">
                            <h4>Empresas</h4>
                            <span class="text-muted">Empresas definidas</span>
                        </div>
                        <div class="col-xs-6 col-sm-3 placeholder">
                            <img src="data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" width="150" height="150" class="img-responsive" alt="Generic placeholder thumbnail">
                            <h4>Clientes</h4>
                            <span class="text-muted">Clientes por empresa</span>
                        </div>
                        <div class="col-xs-6 col-sm-3 placeholder">
                            <img src="data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" width="150" height="150" class="img-responsive" alt="Generic placeholder thumbnail">
                            <h4>Administración</h4>
                            <span class="text-muted">Administración de tablas auxiliares</span>
                        </div>
                        <div class="col-xs-6 col-sm-3 placeholder">
                            <img src="data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" width="150" height="200" class="img-responsive" alt="Generic placeholder thumbnail">
                            <h4>Ayuda</h4>
                            <span class="text-muted">Documentación de ayuda</span>
                        </div>
                    </div>
                    
                    <!-- Código PHP CRUD para presentar los idiomas. -->
                    <h2 class="sub-header">Idiomas</h2>                
 
                    <?php
                        include './database/DatabaseConnect.php';
                        include './database/CbLanguageController.php';
                        
                        $dConnect = new DatabaseConnect;
                        $cdb = $dConnect->dbConnectSimple();
                        
                        $cbLanguageController = new CbLanguageController();                                                           
                        $cbLanguageController->cdb = $cdb;    
                        
                        if (isset($_POST["save-language"]) || isset($_POST["update-language"]) ) {  
                            $idlanguage = $_POST['idlanguage'];
                            $namelanguage = $_POST['namelanguage'];
                            $isactive  = $_POST['isactive'];
                            $languageiso = $_POST['languageiso'];
                            $countrycode = $_POST['countrycode'];
                            $isbaselanguage = $_POST['isbaselanguage'];
                            $issystemlanguage = $_POST['issystemlanguage']; 
                            if (isset($_POST["save-language"])){
                                $cbLanguageController->create($idlanguage, $namelanguage, $isactive, $languageiso, $countrycode, $isbaselanguage, $issystemlanguage);
                            }else{
                                $cbLanguageController->update($idlanguage, $namelanguage, $isactive, $languageiso, $countrycode, $isbaselanguage, $issystemlanguage);
                            }
                        }else if (isset($_POST["delete-language-select"]) ) { 
                            $idlanguageselect = $_POST['idlanguagedelete'];
                            $cbLanguageController->delete($idlanguageselect);
                        }
                        
                        
                    ?>    
            
                    <div class="table-responsive">
                        <!-- Añadimos un botón para el diálogo modal -->
                        <button type="button" 
                                class="btn btn-lg btn-primary" 
                                data-toggle="modal" 
                                data-target="#myModal"
                                onclick="newCbLanguage()"
                                >NUEVO</button>  
                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th>LANGUAGE</th>
                                    <th>NAME</th>
                                    <th>IS ACTIVE?</th>
                                    <th>LANGUAGE ISO</th>
                                    <th>COUNTRY CODE</th>
                                    <th>IS BASE?</th>
                                    <th>IS SYSTEM LANGUAGE?</th>
                                    <th>ACCIONES</th>
                                </tr>
                            </thead>
                            <tbody>
                                <form role="form" name="formListCbLanguage" method="post" action="index.php">
                                <?php
                                try {
                                    $rows = $cbLanguageController->readAll();                                                                        
                                    foreach ($rows as $row) {
                                        ?>
                                        <tr>
                                            <td><?php print($row->idlanguage); ?></td>
                                            <td><?php print($row->namelanguage); ?></td>
                                            <td><?php print($row->isactive); ?></td>
                                            <td><?php print($row->languageiso); ?></td>
                                            <td><?php print($row->countrycode); ?></td>
                                            <td><?php print($row->isbaselanguage); ?></td>
                                            <td><?php print($row->issystemlanguage); ?></td>
                                            <td>
                                                <button id="edit-language" name="edit-language" type="button" 
                                                        class="btn btn-primary"
                                                        data-toggle="modal" 
                                                        data-target="#myModal"
                                                        onclick="openCbLanguage('edit', 
                                                                    '<?php print($row->idlanguage); ?>', '<?php print($row->namelanguage); ?>',
                                                                    '<?php print($row->isactive); ?>', '<?php print($row->languageiso); ?>',
                                                                    '<?php print($row->countrycode); ?>', '<?php print($row->isbaselanguage); ?>',
                                                                    '<?php print($row->issystemlanguage); ?>')">
                                                    Editar</button>
                                                <button id="see-language" name="see-language"type="button" class="btn btn-success"
                                                        data-toggle="modal" 
                                                        data-target="#myModal"
                                                        onclick="openCbLanguage('see', 
                                                                    '<?php print($row->idlanguage); ?>', '<?php print($row->namelanguage); ?>',
                                                                    '<?php print($row->isactive); ?>', '<?php print($row->languageiso); ?>',
                                                                    '<?php print($row->countrycode); ?>', '<?php print($row->isbaselanguage); ?>',
                                                                    '<?php print($row->issystemlanguage); ?>')">
                                                    Ver</button>
                                                <button id="delete-language-modal" name="delete-language-modal" type="button" 
                                                        class="btn btn-danger"
                                                        data-toggle="modal"
                                                        data-target="#myModalDelete"
                                                        onclick="deleteCbLanguage('<?php print($row->idlanguage); ?>')">Eliminar</button>    
                                            </td>
                                            </tr>      
                                        
                                    <?php
                                    }
                                } catch (Exception $exception) {
                                    echo 'Error hacer la consulta: ' . $exception;
                                }
                                ?>     
                                </form>        
                            </tbody>      
                        </table>   
                    </div>
                    
                    <!-- 
                        Create - Read - Update    
                        Creamos una ventana Modal que utilizaremos para crear un nuevo idioma, actualizarlo o mostrarlo.
                        We create a modal window used to create a new language, update or display.-->
                    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" id="myModalLabel">Formulario para un idioma</h4>
                                </div>
                                <form role="form" name="formCbLanguage" method="post" action="index.php">
                                    <div class="modal-body">                                    
                                        <div class="input-group">
                                            <label for="idlanguage">Idioma</label>
                                            <input type="text" class="form-control" id="idlanguage" name="idlanguage" placeholder="es_ES (por ejemplo)" >
                                            <small class="text-muted">Lo utilizamos como ID y se forma con los iso de idioma (es) y país (ES) unidos por un guión bajo.</small>
                                        </div>
                                        <div class="input-group"> 
                                            <label for="namelanguage">Nombre</label>
                                            <input type="text" class="form-control" id="namelanguage" name="namelanguage" placeholder="Nombre" aria-describedby="sizing-addon2">
                                        </div>
                                        <div class="input-group"> 
                                            <label for="isactive">Activo</label>
                                            <input type="text" class="form-control" id="isactive" name="isactive" placeholder="Activo" aria-describedby="sizing-addon2">
                                            <small class="text-muted">Usa el valor Y si está activo y N en caso contrario</small>
                                        </div>                          
                                        <div class="input-group"> 
                                            <label for="languageiso">Iso</label>
                                            <input type="text" class="form-control" id="languageiso" name="languageiso" placeholder="Iso" aria-describedby="sizing-addon2">
                                        </div>
                                        <div class="input-group"> 
                                            <label for="countrycode">Código País</label>
                                            <input type="text" class="form-control" id="countrycode" name="countrycode" placeholder="Código País" aria-describedby="sizing-addon2">
                                        </div>
                                        <div class="input-group"> 
                                            <label for="isbaselanguage">Idioma base</label>
                                            <input type="text" class="form-control" id="isbaselanguage" name="isbaselanguage" placeholder="Es idioma base" aria-describedby="sizing-addon2">
                                            <small class="text-muted">Usa el valor Y si está activo y N en caso contrario</small>
                                        </div>
                                        <div class="input-group"> 
                                            <label for="issystemlanguage">Idioma sistema</label>
                                            <input type="text" class="form-control" id="issystemlanguage" name="issystemlanguage" placeholder="Es el idioma del sistema" aria-describedby="sizing-addon2">
                                            <small class="text-muted">Usa el valor Y si está activo y N en caso contrario</small>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <button id="save-language" name="save-language" type="submit" class="btn btn-primary">Guardar</button>
                                        <button id="update-language" name="update-language" type="submit" class="btn btn-primary">Actualizar</button>
                                        <button id="cancel"type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>                                    
                                    </div>
                                </form>
                            </div><!-- /.modal-content -->
                        </div><!-- /.modal-dialog -->
                    </div><!-- /.modal -->      
                    
                    <!-- Modal DELETE -->
                    <div class="modal fade" id="myModalDelete" tabindex="-1" role="dialog" aria-labelledby="myModalDeleteLabel">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" id="myModalDeleteLabel">Eliminación de idioma</h4>
                                </div>
                                <form role="form" name="formDeleteCbLanguage" method="post" action="index.php">
                                    <div class="modal-body">                                    
                                            <div class="input-group">
                                                <label for="idlanguage">¿Se va a eliminar el registro del idioma seleccionado?</label>
                                            </div>       
                                            <div class="input-group">
                                                <label for="idlanguage">Idioma</label>
                                                <input type="text" readonly class="form-control" id="idlanguagedelete" name="idlanguagedelete" placeholder="es_ES (por ejemplo)" >                                        
                                            </div>
                                    </div>
                                    <div class="modal-footer">
                                            <button id="delete-language-select" name="delete-language-select" type="submit" class="btn btn-primary">Aceptar</button>                                        
                                            <button id="cancel"type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>                                    
                                    </div>
                                </form>
                            </div><!-- /.modal-content -->
                        </div><!-- /.modal-dialog -->
                    </div><!-- /.modal -->    
                    
                    <!-- Fin código PHP CRUD -->
                    
                </div>    
            </div>
        </div>

        <!-- Bootstrap core JavaScript
        ================================================== -->
        <!-- Placed at the end of the document so the pages load faster -->
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
        <script>window.jQuery || document.write('<script src="assets/js/vendor/jquery.min.js"><\/script>')</script>
        <script src="js/bootstrap.min.js"></script>
        <!-- Just to make our placeholder images work. Don't actually copy the next line! -->
        <script src="assets/js/vendor/holder.min.js"></script>
        <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
        <script src="assets/js/ie10-viewport-bug-workaround.js"></script>
        <script>
            /**
             * Abrimos la ventana modal para crear un nuevo elemento.
             * We open a modal window to create a new element.
             * @returns {undefined}
             */
            function newCbLanguage(){                 
                openCbLanguage('new', null, null, null, null, null, null, null);
            }
            /**
             * Abrimos la ventana modal teniendo en cuenta la acción (action) para 
             * utilizarla como creación (Create), lectura (Read) o actualización (Update).
             * We opened the modal window considering the action (action) to use 
             * as creation (Create), reading (Read) or upgrade (Update).
             * @param {type} action las acciones que utilizamos son : new para Create, see para Read y edit para Update.
             *      Actions we use are :  new for Create, see for Read and edit for Update.
             * @param {type} idlanguage
             * @param {type} namelanguage
             * @param {type} isactive
             * @param {type} languageiso
             * @param {type} countrycode
             * @param {type} isbaselanguage
             * @param {type} issystemlanguage
             * @returns {undefined}
             */
            function openCbLanguage(action, idlanguage, namelanguage, isactive, languageiso, countrycode, isbaselanguage, issystemlanguage){    
                document.formCbLanguage.idlanguage.value = idlanguage;
                document.formCbLanguage.namelanguage.value = namelanguage;
                document.formCbLanguage.isactive.value = isactive;
                document.formCbLanguage.languageiso.value = languageiso;
                document.formCbLanguage.countrycode.value = countrycode;
                document.formCbLanguage.isbaselanguage.value = isbaselanguage;
                document.formCbLanguage.issystemlanguage.value = issystemlanguage;
                
                document.formCbLanguage.idlanguage.disabled = (action === 'see')?true:false;                
                document.formCbLanguage.namelanguage.disabled = (action === 'see')?true:false; 
                document.formCbLanguage.isactive.disabled = (action === 'see')?true:false; 
                document.formCbLanguage.languageiso.disabled = (action === 'see')?true:false; 
                document.formCbLanguage.countrycode.disabled = (action === 'see')?true:false; 
                document.formCbLanguage.isbaselanguage.disabled = (action === 'see')?true:false; 
                document.formCbLanguage.issystemlanguage.disabled = (action === 'see')?true:false; 
                
                $('#myModal').on('shown.bs.modal', function () {
                    var modal = $(this);
                    if (action === 'new'){                            
                        $('#save-language').show();
                        $('#update-language').hide();                
                        modal.find('.modal-title').text('Creación de idioma');                    
                    }else if (action === 'edit'){
                        $('#save-language').hide();                    
                        $('#update-language').show();                       
                        modal.find('.modal-title').text('Actualizar idioma');
                    }else if (action === 'see'){
                        $('#save-language').hide();   
                        $('#update-language').hide();                       
                        modal.find('.modal-title').text('Ver idioma');
                    }
                    $('#idlanguage').focus()
                });
            }        
            /**
             * Para borrar el idioma seleccionado abrimos una ventana modal para 
             * que el usuario confirme si quiere eliminar el registro.
             * To delete the selected language we open a modal window for 
             * the user to confirm whether to delete the record.
             * @param {type} idlanguage
             * @returns {undefined}
             */
            function deleteCbLanguage(idlanguage){     
                document.formDeleteCbLanguage.idlanguagedelete.value = idlanguage;                
                
                $('#myModalDelete').on('shown.bs.modal', function () {
                    $('#myInput').focus()
                });
            } 
        </script>
    </body>
</html>