export default class ExceptionHelper {
    public static checkNotNull(arg: any) {
        if (arg == null) return Error(`Value can not be a null.`);
        return arg;
    }
}