export function tagMaker(tagList: string): string[] {
  const parts = tagList
    .split(' ')
    .filter((t) => t !== '')
    .map((t) => t.trim())
    .map((t) => t.toLowerCase());

  return Array.from(new Set(parts));
}
