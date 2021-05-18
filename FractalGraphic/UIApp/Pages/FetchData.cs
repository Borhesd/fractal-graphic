using Blazor.Extensions.Canvas.Canvas2D;
using Blazor.Extensions;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Threading.Tasks;
using UIApp.Data;

namespace UIApp.Pages
{
    public partial class FetchData
    {
        [Inject]
        HttpClient Http { get; set; }

        private Canvas2DContext _context;
        private int pointCount = 100;
        private int width = 400;
        private int height = 400;

        private Point[] points = null;
        protected BECanvasComponent _canvasReference { get; set; }
        protected override async Task OnInitializedAsync() => await GetNewPointList();
        private async Task GetNewPointList() => points = await new SierpinskiFractalsAPI(Http).GetPointsAsync(pointCount, width, height);

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (_canvasReference != null)
            {
                _context = await _canvasReference.CreateCanvas2DAsync();
                await _context.SetFillStyleAsync("green");

                await _context.FillRectAsync(10, 100, 100, 100);

                await _context.SetFontAsync("48px serif");
                await _context.StrokeTextAsync("Hello Blazor!!!", 10, 100);
            }
        }
    }
}
