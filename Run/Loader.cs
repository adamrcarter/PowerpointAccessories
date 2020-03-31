using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Run
{
    public class Loader
    {
        private readonly int xcoord;
        private readonly int ycoord;
        private readonly int fps;
        private bool running;
        private CancellationTokenSource tokenSource;
        private CancellationToken token;
        private delegate void Animate();
        private Action action;
        public Task Task { get; }
        private string caption;
        
        
        public Loader(int xcoord, int ycoord, int fps = 25, string caption = "Loading")
        {
            this.xcoord = xcoord;
            this.ycoord = ycoord;
            this.fps = fps;
            this.tokenSource = new CancellationTokenSource();
            this.token = tokenSource.Token;
            this.action = this.animator;
            this.Task = new Task(action, this.token);
            this.caption = caption;

        }
        private void animator()
        {
            try
            {
                _animator();
            }
            catch (OperationCanceledException)
            {

                
            }
        }
         private void _animator()
        {
            Console.Clear();

            while (!this.tokenSource.IsCancellationRequested)
            {
                if (running == false) break;
                string next = caption;
                Console.Clear();

                for (int i=0; i<10; i++)
                {

                    Console.SetCursorPosition(Console.WindowLeft + (Console.WindowWidth / 2)-i-(caption.Length/2), Console.WindowTop + (Console.WindowHeight / 2));;
                    Console.Write($"{next}");
                    next = $".{next}.";
                    Thread.Sleep(fps);
                }
                

            }
            token.ThrowIfCancellationRequested();
        }

        public void start()
        {
            running = true;
            if(Task.Status != TaskStatus.Running)
            {
                this.Task.Start();
            }

        }

        public void stop()
        {
            running = false;
            if (Task.Status == TaskStatus.Running)
            {
                
                this.tokenSource.Cancel();
            }

        }
    }
}
