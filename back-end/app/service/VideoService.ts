export class Video {
    id: string;
    url: string;
    type: string;
}

export default class VideoService {
    public static getVideos(): Array<Video> {
        return [
            {
                id: '1',
                url: 'public/videos/first.mp4',
                type: 'media/mp4'
            },
            {
                id: '2',
                url: 'public/videos/second.mp4',
                type: 'media/mp4'
            }
        ]
    }
}