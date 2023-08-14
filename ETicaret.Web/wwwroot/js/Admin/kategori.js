let kategoriler=[];
function KategorileriGetir() {
    Get("Kategori/TumKategoriler", (data) => {
        $('#selectUstKategoriler').empty();
        var arr = data;
        $.each(arr, function (i,item) {
            $('#selectUstKategoriler').append($('<option>', {
                value: item.id,
                text: item.ad,
                
            }));
        });
    });
}
function KategoriOzetListeGetir() {
    Get("Kategori/KategoriOzetListe", (data) => {
        var html = `<table class="table table-hover"><tr><th style="width:50px">Sıra</th> <th>Kategori</th> <th>Üst Kategori</th> <th>Aktif</th> <th>işlemler</th> </tr>`;
        var arr = data;
        kategoriler = arr;
        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `<td>${arr[i].sira}</td><td>${arr[i].kategoriAd}</td><td>${arr[i].ustKategoriAd}</td><td>${arr[i].aktif}</td>`;
            html += `<td><i class="bi bi-trash text-danger" onclick='KategoriSil(${arr[i].id})'></i><i class="bi bi-pencil-square" onclick='KategoriDuzenle(${arr[i].id})'></i></td>`;
            html += `</tr>`
        }
        html += `</table>`;

        $("#divKategori").html(html);
    });
}

let selectedKategoriId = 0;

function YeniKategori() {
    selectedKategoriId = 0;
    $("#inputKategoriAd").val();
    $("#inputAktifMi").is(":checked");
    $("#inputSira").val();
    Foto: "";
    $("#selectUstKategoriler").find(":selected").val();
    
    $("#kategoriModal").modal("show");
}
function KategoriKaydet() {
    var kategori = {
        Id: selectedKategoriId,
        Ad: $("#inputKategoriAd").val(),
        Aktif: $("#inputAktifMi").is(":checked"),
        Sira: $("#inputSira").val(),
        Foto: "",
        UstKategoriId: $("#selectUstKategoriler").find(":selected").val()    
    };
    Post("Kategori/Kaydet", kategori, (data) => {
        KategorileriGetir();
        KategoriOzetListeGetir();
        $("#kategoriModal").modal("hide");
    });
}


function KategoriSil(id) {
    Delete(`Kategori/Sil?id=${id}`, (data) => {
        KategorileriGetir();
        KategoriOzetListeGetir();
    });
}

function KategoriDuzenle(id, ad) {
    selectedKategoriId = id;
    Ad: $("#inputKategoriAd").val(ad);
    $("#kategoriModal").modal("show");
}

$(document).ready(function () {
    KategorileriGetir();
    KategoriOzetListeGetir();
});