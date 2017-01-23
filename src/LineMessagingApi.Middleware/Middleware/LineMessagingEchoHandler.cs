using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Yamac.LineMessagingApi.Client;
using Yamac.LineMessagingApi.Message.Template;

namespace Yamac.LineMessagingApi.Middleware
{
    public class LineMessagingEchoHandler : ILineMessagingRequestHandler
    {
        private readonly ILineMessagingApi _api;

        private readonly ILogger _logger;

        public LineMessagingEchoHandler(ILineMessagingApi api, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<LineMessagingEchoHandler>();
            _api = api;
        }

        public void HandleRequest(LineMessagingRequest request)
        {
            // Handle all events.
            request.Events.ToList().ForEach(theEvent =>
            {
                try
                {
                    // Handle each event.
                    HandleEvent(theEvent);
                }
                catch (Exception e)
                {
                    // Ignore exception but logging.
                    _logger.LogError("HandleEvent: Exception={}", e.Message);
                }
            });
        }

        public void HandleEvent(Event.Event theEvent)
        {
            switch (theEvent.Type)
            {
                case Event.EventType.Message:
                    HandleMessageEvent(theEvent as Event.MessageEvent);
                    break;
                case Event.EventType.Follow:
                    ReplyTextMessage((theEvent as Event.FollowEvent).ReplyToken, "Follow");
                    break;
                case Event.EventType.Unfollow:
                    break;
                case Event.EventType.Join:
                    ReplyTextMessage((theEvent as Event.JoinEvent).ReplyToken, $"Join to {theEvent.Source.Type}");
                    break;
                case Event.EventType.Leave:
                    break;
                case Event.EventType.Postback:
                    HandlePostbackEvent(theEvent as Event.PostbackEvent);
                    break;
                case Event.EventType.Beacon:
                    ReplyTextMessage((theEvent as Event.BeaconEvent).ReplyToken, "Beacon");
                    break;
            }
        }

        private void HandleMessageEvent(Event.MessageEvent messageEvent)
        {
            switch (messageEvent.Message.Type)
            {
                case Event.MessageType.Text:
                    HandleTextMessage(messageEvent);
                    break;
                case Event.MessageType.Image:
                    HandleImageMessage(messageEvent);
                    break;
                case Event.MessageType.Video:
                    HandleVideoMessage(messageEvent);
                    break;
                case Event.MessageType.Audio:
                    HandleAudioMessage(messageEvent);
                    break;
                case Event.MessageType.Location:
                    HandleLocationMessage(messageEvent);
                    break;
                case Event.MessageType.Sticker:
                    HandleStickerMessage(messageEvent);
                    break;
                default:
                    ReplyTextMessage(messageEvent.ReplyToken, "Not supported");
                    break;
            }
        }

        private void HandleTextMessage(Event.MessageEvent messageEvent)
        {
            var textMessage = messageEvent.Message as Event.TextMessage;
            var text = textMessage.Text;
            if (string.Compare(text, "/l", true) == 0)
            {
                HandleLeave(messageEvent);
            }
            else if (string.Compare(text, "/tb", true) == 0)
            {
                HandleButtonsTemplate(messageEvent);
            }
            else if (string.Compare(text, "/tco", true) == 0)
            {
                HandleConfirmTemplate(messageEvent);
            }
            else if (string.Compare(text, "/tca", true) == 0)
            {
                HandleCarouselTemplate(messageEvent);
            }
            else
            {
                ReplyTextMessage(messageEvent.ReplyToken, $"Text: Text={textMessage.Text}");
            }
        }

        private void HandleImageMessage(Event.MessageEvent messageEvent)
        {
            var imageMessage = messageEvent.Message as Event.ImageMessage;
            HandleBinaryMessage(imageMessage.Id, $"image-{imageMessage.Id}");
            ReplyTextMessage(messageEvent.ReplyToken, "Image: Saved");
        }

        private void HandleVideoMessage(Event.MessageEvent messageEvent)
        {
            var videoMessage = messageEvent.Message as Event.VideoMessage;
            HandleBinaryMessage(videoMessage.Id, $"video-{videoMessage.Id}");
            ReplyTextMessage(messageEvent.ReplyToken, "Video: Saved");
        }

        private void HandleAudioMessage(Event.MessageEvent messageEvent)
        {
            var audioMessage = messageEvent.Message as Event.AudioMessage;
            HandleBinaryMessage(audioMessage.Id, $"audio-{audioMessage.Id}");
            ReplyTextMessage(messageEvent.ReplyToken, "Audio: Saved");
        }

        private void HandleLocationMessage(Event.MessageEvent messageEvent)
        {
            var locationMessage = messageEvent.Message as Event.LocationMessage;
            ReplyTextMessage(messageEvent.ReplyToken, $"Location: Title={locationMessage.Title},Address={locationMessage.Address}");
        }

        private void HandleStickerMessage(Event.MessageEvent messageEvent)
        {
            var stickerMessage = messageEvent.Message as Event.StickerMessage;
            ReplyTextMessage(messageEvent.ReplyToken, $"Sticker: Id={stickerMessage.PackageId},{stickerMessage.StickerId}");
        }

        private void HandleBinaryMessage(string messageId, string filename)
        {
            using (var inputStream = _api.GetMessageContent(messageId))
            using (var memoryStream = new MemoryStream())
            using (var outputStream = new FileStream(filename, FileMode.CreateNew))
            {
                inputStream.CopyTo(memoryStream);
                outputStream.Write(memoryStream.ToArray(), 0, (int)memoryStream.Length);
            }
        }

        private void HandleLeave(Event.MessageEvent messageEvent)
        {
            switch (messageEvent.Source.Type)
            {
                case Event.SourceType.Group:
                    _api.LeaveGroup(messageEvent.Source.SenderId);
                    break;
                case Event.SourceType.Room:
                    _api.LeaveRoom(messageEvent.Source.SenderId);
                    break;
                default:
                    break;
            }
        }

        private void HandleButtonsTemplate(Event.MessageEvent messageEvent)
        {
            var templateMessage = new Message.TemplateMessage();
            templateMessage.AltText = "AltText";
            templateMessage.Template = new ButtonsTemplate();

            var template = templateMessage.Template as ButtonsTemplate;
            template.ThumbnailImageUrl = "https://static.line.naver.jp/line_regulation/files/ver2/LINE_Icon.png";
            template.Title = "Title";
            template.Text = "Text";
            template.Actions.Add(new PostbackAction
            {
                Label = "Label 1",
                Data = "Data 1",
                //Text = "Text 1",
            });
            template.Actions.Add(new MessageAction
            {
                Label = "Label 2",
                Text = "Text 2",
            });
            template.Actions.Add(new UriAction
            {
                Label = "Label 3",
                Uri = "https://www.line.me/",
            });

            var message = new Message.ReplyMessage(messageEvent.ReplyToken, templateMessage);
            _api.ReplyMessage(message);
        }

        private void HandleConfirmTemplate(Event.MessageEvent messageEvent)
        {
            var templateMessage = new Message.TemplateMessage();
            templateMessage.AltText = "AltText";
            templateMessage.Template = new ConfirmTemplate();

            var template = templateMessage.Template as ConfirmTemplate;
            template.Text = "Text";
            template.Actions.Add(new MessageAction
            {
                Label = "Label 1",
                Text = "Text 1",
            });
            template.Actions.Add(new MessageAction
            {
                Label = "Label 2",
                Text = "Text 2",
            });

            var message = new Message.ReplyMessage(messageEvent.ReplyToken, templateMessage);
            _api.ReplyMessage(message);
        }

        private void HandleCarouselTemplate(Event.MessageEvent messageEvent)
        {
            var templateMessage = new Message.TemplateMessage();
            templateMessage.AltText = "AltText";
            templateMessage.Template = new CarouselTemplate();

            var template = templateMessage.Template as CarouselTemplate;
            template.Columns.Add(new CarouselColumn
            {
                ThumbnailImageUrl = "https://static.line.naver.jp/line_regulation/files/ver2/LINE_Icon.png",
                Title = "Title 1",
                Text = "Text 1",
            });
            template.Columns[0].Actions.Add(new PostbackAction
            {
                Label = "Label 1-1",
                Data = "Data 1-1",
                //Text = "Text 1-1",
            });
            template.Columns[0].Actions.Add(new MessageAction
            {
                Label = "Label 1-2",
                Text = "Text 1-2",
            });
            template.Columns[0].Actions.Add(new UriAction
            {
                Label = "Label 1-3",
                Uri = "https://www.line.me/",
            });
            template.Columns.Add(new CarouselColumn
            {
                ThumbnailImageUrl = "https://static.line.naver.jp/line_regulation/files/ver2/LINE_Icon.png",
                Title = "Title 2",
                Text = "Text 2",
            });
            template.Columns[1].Actions.Add(new PostbackAction
            {
                Label = "Label 2-1",
                Data = "Data 2-1",
                //Text = "Text 2-1",
            });
            template.Columns[1].Actions.Add(new MessageAction
            {
                Label = "Label 2-2",
                Text = "Text 2-2",
            });
            template.Columns[1].Actions.Add(new UriAction
            {
                Label = "Label 2-3",
                Uri = "https://www.line.me/",
            });

            var message = new Message.ReplyMessage(messageEvent.ReplyToken, templateMessage);
            _api.ReplyMessage(message);
        }

        private void HandlePostbackEvent(Event.PostbackEvent postbackEvent)
        {
            ReplyTextMessage(postbackEvent.ReplyToken, $"Postback: Data={postbackEvent.Postback.Data}");
        }

        private void ReplyTextMessage(string replyToken, string text)
        {
            var message = new Message.ReplyMessage(
                replyToken,
                new Message.TextMessage
                {
                    Text = text,
                });
            _api.ReplyMessage(message);
        }

        private void PushTextMessage(string to, string text)
        {
            var message = new Message.PushMessage(
                to,
                new Message.TextMessage
                {
                    Text = text,
                });
            _api.PushMessage(message);
        }

        private void MulticastText(List<string> to, string text)
        {
            var message = new Message.Multicast(
                to,
                new Message.TextMessage
                {
                    Text = text,
                });
            _api.Multicast(message);
        }
    }
}
