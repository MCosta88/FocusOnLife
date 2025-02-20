$(function () {
    // Inicializa o Kendo UI Grid
    var grid = $("#grdCondominios").kendoGrid({
        //dataSource: {
        //    transport: {
        //        read: {
        //            url: "https://localhost:7032/api/Condominios",  // Endereço da API para buscar os dados dos condomínios
        //            dataType: "json",
        //            data: function () {
        //                return getFilterValues(); // Obtém os valores do filtro dinamicamente
        //            }
        //        }
        //    },
        //    schema: {
        //        model: {
        //            id: "id",
        //            fields: {
        //                nome: { type: "string" },
        //                ativo: { type: "boolean" },
        //                localidade: { type: "string" }
        //            }
        //        }
        //    },
        //    pageSize: 10, // Limitar o número de registros por página
        //    pageable: true,
        //    filterable: true,
        //    sortable: true
        //},
        columns: [
            { field: "nome", title: "Nome" },
            { field: "ativo", title: "Ativo", template: "#= ativo ? 'Ativo' : 'Desativado' #" },
            { field: "localidade", title: "Localidade" }
        ]
    }).data("kendoGrid");

    // Função para obter os valores do filtro
    function getFilterValues() {
        return {
            nome: $("#nome").val(),
            ativo: $("#ativo").val() === "true", // Converte string para booleano
            localidade: $("#localidade").val()
        };
    }

    // Função para filtrar os condomínios
    $("#filtrar").click(function () {
        var filters = [];

        // Adiciona filtros dinamicamente
        if ($("#nome").val()) {
            filters.push({ field: "nome", operator: "contains", value: $("#nome").val() });
        }
        if ($("#ativo").val()) {
            filters.push({ field: "ativo", operator: "eq", value: $("#ativo").val() === "true" });
        }
        if ($("#localidade").val()) {
            filters.push({ field: "localidade", operator: "contains", value: $("#localidade").val() });
        }

        // Aplica os filtros à Grid
        grid.dataSource.filter(filters);
    });
});
