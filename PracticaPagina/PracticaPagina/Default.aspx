<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PracticaPagina.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="Presentacion">
        <div class="GreyBack">
            <div class="container">
                <div class="row">
                    <div class="col aux">
                        <img src="Img/MyPic.jpeg" alt="" id="FotoID">
                    </div>
                    <div class="col aux">
                        <h1>Santino Boscatto</h1>
                        <p>
                            Lorem ipsum dolor sit amet consectetur, adipisicing elit. Sit recusandae dolorem, maiores provident
                            eveniet neque perferendis, cum reiciendis est, porro ducimus quis veniam voluptatum deleniti 
                            optio similique ex. Commodi, ex.
                        </p>
                        <p>
                            Lorem ipsum dolor sit amet consectetur, adipisicing elit. Sit recusandae dolorem, maiores provident
                            eveniet neque perferendis, cum reiciendis est, porro ducimus quis veniam voluptatum deleniti 
                            optio similique ex. Commodi, ex.
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="MisConocimientos">
        <div class="back">
            <h2 id="Dos">Mis Aptitudes</h2>
            <div class="Test-Conocimiento">
                    <div class="carta_Proyecto grid-item sharp">
                        <div class="align">
                            <span class="red"></span>
                            <span class="yellow"></span>
                            <span class="green"></span>
                        </div>
                        <img src="Img/LogoCSharp.png" alt="" class="Logo">
                        <ul class="list-aling">
                            <li>Operaciones CRUD con bases de datos utilizando ADO.NET</li>
                            <li>Desarrollo de Apps Webs y de Escritorio</li>
                            <li>Implementación de patrones de diseño</li>
                            <li>Creación y consumo de servicios web con ASP.NET</li>
                        </ul>
                </div>
                    <div class="carta_Proyecto grid-item Sql">
                        <!-- SQL -->
                        <div class="align">
                            <span class="red"></span>
                            <span class="yellow"></span>
                            <span class="green"></span>
                        </div>
                        <img src="Img/LogoSql.png" alt="" class="Logo">
                        <ul class="list-aling">
                            <li>Creación y optimización de consultas SQL</li>
                            <li>Diseño básico de estructuras de base de datos</li>
                            <li>Uso de JOINs para combinar datos de múltiples tablas</li>
                            <li>Uso de procedimientos almacenados y funciones</li>
                        </ul>
                    </div>
                    <div class="carta_Proyecto grid-item CSS">
                        <!-- HTML y CSS -->
                        <div class="align">
                            <span class="red"></span>
                            <span class="yellow"></span>
                            <span class="green"></span>
                        </div>
                        <img src="Img/Hmtl-CSS.png" alt="" class="Logo">
                        <ul class="list-aling">
                            <li>Implementación de una estructura HTML semántica y coherente</li>
                            <li>Uso de flexbox y de grid para layouts CSS.</li>
                            <li>Uso de animaciones y transiciones CSS.</li>
                            <li>Creación de páginas web estáticas y responsive.</li>
                        </ul>
                    </div>
                    <div class="carta_Proyecto grid-item NET">
                        <!-- .NET -->
                        <div class="align">
                            <span class="red"></span>
                            <span class="yellow"></span>
                            <span class="green"></span>
                        </div>
                        <img src="Img/LogoNet.png" alt="" class="Logo">
                        <ul class="list-aling">
                            <li>Desarrollo de Apps con .NET y .NET Core.</li>
                            <li>Conocimientos básicos de arquitectura MVC</li>
                            <li>Uso de bibliotecas y paquetes NuGet</li>
                            <li>Integración de servicios y APIs externas en aplicaciones .NET.</li>
                        </ul>
                    </div>
                    <div class="carta_Proyecto grid-item Boot">
                        <div class="align">
                            <span class="red"></span>
                            <span class="yellow"></span>
                            <span class="green"></span>
                        </div>
                        <img src="Img/LogoBoot.png" alt="" class="Logo">
                        <ul class="list-aling">
                            <li>Creación de diseños simples y responsivos utilizando el grid system de Bootstrap.</li>
                            <li>Utilización de plugins y extensiones de Bootstrap para mejorar la funcionalidad.</li>
                            <li>Uso de componentes predefinidos como Navbar, Cards y Modals.</li>
                        </ul>
                    </div>
                    <div class="carta_Proyecto grid-item angular">
                        <div class="align">
                            <span class="red"></span>
                            <span class="yellow"></span>
                            <span class="green"></span>
                        </div>
                        <img src="Img/Angular.png" alt="" class="Logo">
                        <ul class="list-aling">
                            <li>Operaciones CRUD contra BD con ADO .NET</li>
                            <li>Desarrollo de Apps Webs y de Escritorio</li>
                            <li>Implementación de patrones de diseño</li>
                            <li>Creación y consumo de servicios web con ASP.NET</li>
                        </ul>
                    </div>
        </div>
        </div>

    </section>
    <section class="MisProyectos">
        <div class="Fondo-Trasparente">
            <h2>Proyectos </h2>
            <div class="Test">
                <div class="container2">
                    <div class="card2 Left">
                        <div class="front2">
                            <h3>Touge App</h3>
                            <img src="Img/P1.png" alt="">
                        </div>
                        <div class="back2">
                            <p>App de Escritorio que simula un modo Gran Turismo para juegos de carreras.</p>
                            <ul>
                                <li>Operaciones Crud contra Base de Datos utilizando SQL Server.</li>
                                <li>Registro de carreras accesible Mediante un DataGridView.</li>
                                <li>Creacion de Pools randomizadas de objetos.</li>
                                <li>Reproductor de Musica, Validaciones y empleo de manejo de excepciones.</li>
                                <li>Conexion con App Web, Car Dealer donde ejerce de concesionaria.</li>
                                <a href="https://github.com/SantinoNicolasBoscatto/Proyectos-Finales/tree/main/P4_Touge-App" target="_blank">
                                    <img src="Img/Git.png" alt="">
                                </a>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="container2">
                    <div class="card2">
                        <div class="front2">
                            <h3>Touge App</h3>
                            <img src="Img/P1.png" alt="">
                        </div>
                        <div class="back2">
                            <p>App de Escritorio que simula un modo Gran Turismo para juegos de carreras.</p>
                            <ul>
                                <li>Operaciones Crud contra Base de Datos utilizando SQL Server.</li>
                                <li>Registro de carreras accesible Mediante un DataGridView.</li>
                                <li>Creacion de Pools randomizadas de objetos.</li>
                                <li>Reproductor de Musica, Validaciones y empleo de manejo de excepciones.</li>
                                <li>Conexion con App Web, Car Dealer donde ejerce de concesionaria.</li>
                                <a href="https://github.com/SantinoNicolasBoscatto/Proyectos-Finales/tree/main/P4_Touge-App" target="_blank">
                                    <img src="Img/Git.png" alt="">
                                </a>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="container2">
                    <div class="card2 right">
                        <div class="front2">
                            <h3>Touge App</h3>
                            <img src="Img/P1.png" alt="">
                        </div>
                        <div class="back2">
                            <p>App de Escritorio que simula un modo Gran Turismo para juegos de carreras.</p>
                            <ul>
                                <li>Operaciones Crud contra Base de Datos utilizando SQL Server.</li>
                                <li>Registro de carreras accesible Mediante un DataGridView.</li>
                                <li>Creacion de Pools randomizadas de objetos.</li>
                                <li>Reproductor de Musica, Validaciones y empleo de manejo de excepciones.</li>
                                <li>Conexion con App Web, Car Dealer donde ejerce de concesionaria.</li>
                                <a href="https://github.com/SantinoNicolasBoscatto/Proyectos-Finales/tree/main/P4_Touge-App" target="_blank">
                                    <img src="Img/Git.png" alt="">
                                </a>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="container2">
                    <div class="card2 Left">
                        <div class="front2">
                            <h3>Touge App</h3>
                            <img src="Img/P1.png" alt="">
                        </div>
                        <div class="back2">
                            <p>App de Escritorio que simula un modo Gran Turismo para juegos de carreras.</p>
                            <ul>
                                <li>Operaciones Crud contra Base de Datos utilizando SQL Server.</li>
                                <li>Registro de carreras accesible Mediante un DataGridView.</li>
                                <li>Creacion de Pools randomizadas de objetos.</li>
                                <li>Reproductor de Musica, Validaciones y empleo de manejo de excepciones.</li>
                                <li>Conexion con App Web, Car Dealer donde ejerce de concesionaria.</li>
                                <a href="https://github.com/SantinoNicolasBoscatto/Proyectos-Finales/tree/main/P4_Touge-App" target="_blank">
                                    <img src="Img/Git.png" alt="">
                                </a>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="container2">
                    <div class="card2">
                        <div class="front2">
                            <h3>Touge App</h3>
                            <img src="Img/P1.png" alt="">
                        </div>
                        <div class="back2">
                            <p>App de Escritorio que simula un modo Gran Turismo para juegos de carreras.</p>
                            <ul>
                                <li>Operaciones Crud contra Base de Datos utilizando SQL Server.</li>
                                <li>Registro de carreras accesible Mediante un DataGridView.</li>
                                <li>Creacion de Pools randomizadas de objetos.</li>
                                <li>Reproductor de Musica, Validaciones y empleo de manejo de excepciones.</li>
                                <li>Conexion con App Web, Car Dealer donde ejerce de concesionaria.</li>
                                <a href="https://github.com/SantinoNicolasBoscatto/Proyectos-Finales/tree/main/P4_Touge-App" target="_blank">
                                    <img src="Img/Git.png" alt="">
                                </a>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="container2">
                    <div class="card2 right">
                        <div class="front2">
                            <h3>Touge App</h3>
                            <img src="Img/P1.png" alt="">
                        </div>
                        <div class="back2">
                            <p>App de Escritorio que simula un modo Gran Turismo para juegos de carreras.</p>
                            <ul>
                                <li>Operaciones Crud contra Base de Datos utilizando SQL Server.</li>
                                <li>Registro de carreras accesible Mediante un DataGridView.</li>
                                <li>Creacion de Pools randomizadas de objetos.</li>
                                <li>Reproductor de Musica, Validaciones y empleo de manejo de excepciones.</li>
                                <li>Conexion con App Web, Car Dealer donde ejerce de concesionaria.</li>
                                <a href="https://github.com/SantinoNicolasBoscatto/Proyectos-Finales/tree/main/P4_Touge-App" target="_blank">
                                    <img src="Img/Git.png" alt="">
                                </a>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
  <%--  <div class="Test">
        <div class="q"></div>
        <div class="w"></div>
        <div class="e"></div>
        <div class="r"></div>
        <div class="t"></div>
        <div class="y"></div>
    </div> --%>
</asp:Content>
