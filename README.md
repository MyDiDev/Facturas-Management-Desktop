# Manejo de Facturas Desktop
[![](https://img.shields.io/badge/Version-1.0-green)]()


Aplicacion Desktop desarollada para manejar registrod de facturas, agregar, eliminar y leer registros junto con la generacion de reportes automatizada.

## Instalacion

- Solo Clona el Repositorio:

```bash
git clone https://github.com/MyDiDev/Facturas-Management-Desktop
```

Ve al Directorio Generado y Abrelo en Visual Studio

```bash
cd Facturas-Management-Desktop
```


## Contribucion

- Haz un **Fork** del Repositorio 

- **Clona** tu Fork:
    ```bash 
    git clone https://github.com/MyDiDev/Facturas-Management-Desktop.git
    ```
- **Crea** una nueva Rama:
    ```bash
    git checkout -b feature/nombre-feature
    ```
- **Haz tus Cambios** y el Commit:
    ```bash
    git commit -m "commit"
    ```
- **Push al fork**:
    ```bash
    git push origin feature/nombre-feature
    ```
- **Abre un pull request** y describelo.

---

## 📄 Guía Rápida para Usar ReportViewer en C# WinForms

### 1. Instalación del Control ReportViewer

Si no ves el control ReportViewer en el cuadro de herramientas de Visual Studio, sigue estos pasos:

1. **Instalar la extensión necesaria**:

   * Abre Visual Studio.
   * Ve a **Extensiones > Administrar extensiones**.
   * Busca e instala **Microsoft RDLC Report Designer**.

2. **Agregar el control al cuadro de herramientas**:

   * Haz clic derecho en el cuadro de herramientas y selecciona **Elegir elementos...**.
   * En la ventana que aparece, busca **ReportViewer** y marca la casilla correspondiente.
   * Haz clic en **Aceptar**.

3. **Instalar los paquetes NuGet necesarios**:

   * Abre la **Consola del Administrador de Paquetes NuGet** desde **Herramientas > Administrador de paquetes NuGet > Consola del Administrador de Paquetes**.
   * Ejecuta los siguientes comandos:

     ```bash
     Install-Package Microsoft.ReportingServices.ReportViewerControl.WinForms
     Install-Package Microsoft.ReportViewer.WinForms.v12
     ```


     Estos paquetes proporcionan las bibliotecas necesarias para utilizar el control ReportViewer en tu proyecto.

---

### 2. Crear un Informe RDLC

1. **Agregar un nuevo informe RDLC**:

   * Haz clic derecho en el proyecto y selecciona **Agregar > Nuevo elemento...**.
   * Elige **Informe de datos de informe de cliente (RDLC)** y asígnale un nombre, por ejemplo, `Factura.rdlc`.

2. **Diseñar el informe**:

   * Abre el archivo `Factura.rdlc`.
   * Utiliza el diseñador de informes para arrastrar y soltar campos desde un origen de datos, como un DataSet tipado o una lista de objetos.

---

### 3. Cargar y Mostrar el Informe en el Formulario

En el formulario donde deseas mostrar el informe:

1. **Agregar el control ReportViewer**:

   * Arrastra el control **ReportViewer** desde el cuadro de herramientas al formulario.

2. **Configurar el control ReportViewer**:

   * En el evento `Load` del formulario, configura el control ReportViewer para que utilice el informe RDLC y los datos correspondientes:

     ```csharp
     private void Form1_Load(object sender, EventArgs e)
     {
         var encabezado = new List<EncabezadoFactura>(); // Lista de encabezado
         var detalle = new List<DetalleFactura>(); // Lista de detalles

         var parametros = new ReportParameter[]
         {
             new ReportParameter("Titulo", "Factura de Ejemplo"),
             new ReportParameter("Empresa", "Mi Empresa S.A.")
         };

         reportViewer1.LocalReport.ReportPath = @"C:\Ruta\Al\Informe\Factura.rdlc";
         reportViewer1.LocalReport.DataSources.Clear();
         reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Encabezado", encabezado));
         reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Detalle", detalle));
         reportViewer1.LocalReport.SetParameters(parametros);
         reportViewer1.RefreshReport();
     }
     ```
     Este código carga el informe RDLC y le asigna los datos y parámetros necesarios.

---

### 4. Generar el Informe en PDF

Para exportar el informe a PDF:

1. **Agregar un botón para exportar**:

   * Coloca un botón en el formulario, por ejemplo, `btnExportar`.

2. **Configurar el evento Click del botón**:

   * En el evento `Click` del botón, agrega el siguiente código:

     ```csharp
     private void btnExportar_Click(object sender, EventArgs e)
     {
         byte[] bytes = reportViewer1.LocalReport.Render("PDF");
         File.WriteAllBytes(@"C:\Ruta\Al\Archivo\Factura.pdf", bytes);
     }
     ```

     Este código genera el informe en formato PDF y lo guarda en la ruta especificada.

---

### 5. Recursos Adicionales

* **Documentación oficial**: [Usar el control ReportViewer en aplicaciones de Windows Forms](https://learn.microsoft.com/es-es/sql/reporting-services/application-integration/using-the-winforms-reportviewer-control?view=sql-server-ver16)
* **Tutorial paso a paso**: [Creando informes desde un DataSet con ReportViewer](https://www.c-sharpcorner.com/article/building-reports-from-a-dataset-using-reportviewer/)
* **Ejemplo de factura con RDLC**: [Parvulos.Net: ReportViewer y RDLC, ejemplo Factura](https://joseluisgarciab.blogspot.com/2013/10/reportviewer-y-rdlc-ejemplo-facturacion.html)

---

## Authores

- [@MyDiDev](https://www.github.com/MyDiDev)
