document.addEventListener("DOMContentLoaded", function () {
    const loginForm = document.getElementById("login-form");
    const errorMessage = document.getElementById("error-message");

    // Verificar se já está autenticado
    if (sessionStorage.getItem("authToken")) {
        window.location.href = "/Admin/Dashboard";  // Redireciona se o usuário já estiver logado
    }

    loginForm.addEventListener("submit", async function (event) {
        event.preventDefault();

        let email = document.getElementById("email").value;
        let password = document.getElementById("password").value;

        try {
            // Realizar a requisição POST para o login
            let response = await axios.post("https://localhost:7032/api/Auth/login", {
                email: email,
                password: password
            });

            if (response.data.token) {
                // Se o token for retornado, salvar no sessionStorage
                sessionStorage.setItem("authToken", response.data.token);

                // Configurar o token no axios para requisições subsequentes
                axios.defaults.headers.common['Authorization'] = `Bearer ${response.data.token}`;

                window.location.href = "/Dashboard/Dashboard";  // Redirecionar para a dashboard do admin
            } else {
                showError("Credenciais inválidas.");
            }
        } catch (error) {
            // Verificar o erro e exibir uma mensagem adequada
            if (error.response) {
                showError(error.response.data.message || "Erro ao conectar com a API.");
            } else {
                showError("Erro de rede ou conexão com a API.");
            }
        }
    });

    function showError(message) {
        // Exibir a mensagem de erro no HTML
        errorMessage.textContent = message;
        errorMessage.classList.remove("d-none");
    }
});
