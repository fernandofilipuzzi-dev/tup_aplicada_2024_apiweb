<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="webapi.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Subir Archivo</h1>

<form id="uploadForm">
    <input type="file" id="fileInput" name="file" />
    <button type="submit">Subir Archivo</button>
</form>

<div id="message"></div>

<script>
    document.getElementById('uploadForm').addEventListener('submit', async function (e) {
        e.preventDefault();

        // Obtén el archivo seleccionado del input
        const fileInput = document.getElementById('fileInput');
        const file = fileInput.files[0];

        if (!file) {
            document.getElementById('message').textContent = 'Por favor selecciona un archivo';
            return;
        }

        // Crea un FormData para enviar el archivo
        const formData = new FormData();
        formData.append('file', file);

        try {
            // Llamada a la API usando fetch
            const response = await fetch('https://localhost:5000/api/Ficheros/upload', {
                method: 'POST',
                body: formData,
                headers: {
                    // El contenido del body es form/multipart
                }
            });

            // Verificar si la respuesta fue exitosa
            if (response.ok) {
                const data = await response.json();
                document.getElementById('message').textContent = `Archivo subido con éxito: ${data.fileName}`;
            } else {
                const error = await response.text();
                document.getElementById('message').textContent = `Error: ${error}`;
            }
        } catch (error) {
            document.getElementById('message').textContent = `Error en la subida: ${error.message}`;
        }
    });
</script>
</asp:Content>
